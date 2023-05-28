﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Transactions;
using Dapper;
using GestionDeProductos.Domain;
using Microsoft.Win32;
using static Dapper.SqlMapper;

namespace GestionDeProductos.DataAccess.Repository.Sql
{
    public abstract class SqlRepository1<T> : IRepository<T> where T : class
    {
        protected IDbConnection connection;
        protected IDbTransaction tran;
        protected string tableName;

        protected SqlRepository1(IDbConnection connection)
        {
            this.connection = connection;
            tableName = GetTableName();
        }

        protected string GetTableName()
        {
            var tableAttribute = typeof(T).GetCustomAttribute<DbTableNameAttribute>();
            if (tableAttribute != null)
                return tableAttribute.TableName;

            return typeof(T).Name;
        }

        public T SelectOne(object whereParams)
        {
            var parameters = new Dictionary<string, object>();
            var whereClause = BuildWhereClause(whereParams, parameters);

            var query = $"SELECT {GenerateFieldList()} FROM {tableName}";
            if (!string.IsNullOrEmpty(whereClause))
            {
                query += $" WHERE {whereClause}";
            }

            return connection.QueryFirstOrDefault<T>(query, parameters);
        }

        public T SelectOne(T whereParams)
        {
            var parameters = new Dictionary<string, object>();
            var whereClause = BuildWhereClause(whereParams, parameters);

            var query = $"SELECT {GenerateFieldList()} FROM {tableName}";
            if (!string.IsNullOrEmpty(whereClause))
            {
                query += $" WHERE {whereClause}";
            }

            return connection.QueryFirstOrDefault<T>(query, parameters);
        }

        private string GenerateFieldList()
        {
            var fields = typeof(T).GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(DbNameAttribute)))
                .Select(p => $"[{GetColumnName(p)}]")
                .ToList();

            return string.Join(", ", fields);
        }

        private string BuildWhereClause(object whereParams, IDictionary<string, object> parameters)
        {
            if (whereParams == null)
                return null;

            var properties = new List<PropertyInfo>();

            if (whereParams is T typedWhereParams)
            {
                properties = typeof(T).GetProperties()
                    .Where(p => Attribute.IsDefined(p, typeof(DbNameAttribute)) && ((DbNameAttribute)Attribute.GetCustomAttribute(p, typeof(DbNameAttribute))).IsId)
                    .ToList();
            }
            else if (whereParams != null)
            {
                properties = whereParams.GetType().GetProperties().ToList();
            }
            else
            {
                properties = typeof(T).GetProperties()
                    .Where(p => Attribute.IsDefined(p, typeof(DbNameAttribute)))
                    .ToList();
            }

            var conditions = new List<string>();
            foreach (var property in properties)
            {
                var value = property.GetValue(whereParams);
                if (value != null)
                {
                    var paramName = property.Name;
                    parameters[paramName] = value;

                    var columnName = GetColumnName(property);
                    var condition = $"{columnName} = @{paramName}";
                    conditions.Add(condition);
                }
            }

            return conditions.Count > 0 ? string.Join(" AND ", conditions) : null;
        }

        private string GetColumnName(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<DbNameAttribute>();
            return attribute != null ? attribute.ColumnName : property.Name;
        }

        public IEnumerable<T> SelectAll(object whereParams = null)
        {
            var parameters = new Dictionary<string, object>();
            var whereClause = BuildWhereClause(whereParams, parameters);

            var query = $"SELECT {GenerateFieldList()} FROM {tableName}";
            if (!string.IsNullOrEmpty(whereClause))
            {
                query += $" WHERE {whereClause}";
            }

            return connection.Query<T>(query, parameters);
        }
        

        public virtual int Insert(T entity)
        {
            var parameters = GetParametersFromObject(entity);
            string columns = string.Join(", ", parameters
                .Where(p => !Attribute.IsDefined(typeof(T).GetProperty(p.Key), typeof(DbNameAttribute)) || !((DbNameAttribute)Attribute.GetCustomAttribute(typeof(T).GetProperty(p.Key), typeof(DbNameAttribute))).IsId)
                .Select(p => p.Key));

            string values = string.Join(", ", parameters
                .Where(p => !Attribute.IsDefined(typeof(T).GetProperty(p.Key), typeof(DbNameAttribute)) || !((DbNameAttribute)Attribute.GetCustomAttribute(typeof(T).GetProperty(p.Key), typeof(DbNameAttribute))).IsId)
                .Select(p => $"@{p.Key}"));

            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            return connection.Execute(query, parameters.ToDictionary(p => p.Key, p => p.Value), tran);
        }

        public virtual int Update(T entity, object whereParams)
        {
            var parameters = GetParametersFromObject(entity);

            string setStatements = string.Join(", ", parameters
            .Where(p => !Attribute.IsDefined(typeof(T).GetProperty(p.Key), typeof(DbNameAttribute)) || !((DbNameAttribute)Attribute.GetCustomAttribute(typeof(T).GetProperty(p.Key), typeof(DbNameAttribute))).IsId)
            .Select(p => $"{p.Key} = @{p.Key}"));

            var whereClause = BuildWhereClause(whereParams ?? entity, parameters);
            string query = $"UPDATE {tableName} SET {setStatements}";

            if (!string.IsNullOrEmpty(whereClause))
            {
                query += $" WHERE {whereClause}";
            }

            return connection.Execute(query, parameters.ToDictionary(p => p.Key, p => p.Value), tran);
        }

        public virtual int Delete(object whereParams)
        {
            var parameters = new Dictionary<string, object>();
            var whereClause = BuildWhereClause(whereParams, parameters);

            string query = $"DELETE FROM {tableName}";

            if (!string.IsNullOrEmpty(whereClause))
            {
                query += $" WHERE {whereClause}";
            }

            return connection.Execute(query, parameters, tran);
        }

        private Dictionary<string, object> GetParametersFromObject(T entity)
        {
            var parameters = new Dictionary<string, object>();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DbNameAttribute>();
                if (attribute != null)
                {
                    string columnName = attribute.ColumnName ?? property.Name;
                    object value = property.GetValue(entity);
                    parameters.Add(columnName, value);
                }
            }

            return parameters;
        }

        public virtual void Open()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            tran = connection.BeginTransaction();
        }

        public virtual void Commit()
        {
            tran.Commit();
            tran = null;
        }

        public virtual void Rollback()
        {
            tran.Rollback();
            tran = null;
        }

        public void PreloadCache()
        {
            throw new NotImplementedException();
        }
    }
}