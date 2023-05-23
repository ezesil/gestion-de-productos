using Dapper;
using GestionDeProductos.DataAccess.Interfaces;
using GestionDeProductos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GestionDeProductos.Tools.Flags;

namespace GestionDeProductos.DataAccess.Repository.Sql
{
    /// <summary>
    /// Clase abstracta que contiene la implementacion necesaria para el tratamiento de repositorios.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAdapter"></typeparam>
    public abstract class SqlRepository
    {
        private static string connString { get => Environment.GetEnvironmentVariable("mssql_connstring"); }


        /// <summary>
        /// Constructor por defecto para el funcionamiento basico de todas las querys.
        /// </summary>
        public SqlRepository()
        {
        }

        /// <summary>
        /// Obtiene un objeto.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual async Task<int> Query(string query, object parameters = null)
        {
            try
            {
                //Using the dynamic parameters like usual
                using (var con = new SqlConnection(connString))
                {
                    var results = await con.QueryAsync<int>(query, GetParameters(parameters, query));
                    return results.FirstOrDefault();
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene un objeto.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual async Task<T> QuerySingle<T>(string query, object parameters = null)
        {
            try
            {
                //Using the dynamic parameters like usual
                using (var con = new SqlConnection(connString))
                {
                    var results = await con.QueryAsync<T>(query, GetParameters(parameters, query));
                    return results.FirstOrDefault();
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene un objeto.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> QueryMultiple<T>(string query, object parameters = null)
        {
            try
            {

                //Using the dynamic parameters like usual
                using (var con = new SqlConnection(connString))
                {
                    var results = await con.QueryAsync<T>(query, GetParameters(parameters, query));
                    return results;
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }

             
        /// <summary>
        /// Obtiene un array de SqlParameter a partir de las propiedades del objeto especificado mientras se filtra por una query.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetParameters(object args, string query)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (args == null)
                return parameters;

            Type myType = args.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            object? value = null;
            ColumnName? tableNameFlag = null;
            foreach (PropertyInfo prop in props)
            {
                value = prop.GetValue(args, null);
                tableNameFlag = prop.GetFlag<ColumnName>();

                if (tableNameFlag != null && query.ToLower().Contains($"@{tableNameFlag.Name.ToLower()}"))
                {
                    parameters.Add(tableNameFlag.Name, prop.GetValue(args, null));
                }
                else if (query.ToLower().Contains($"@{prop.Name.ToLower()}") && value != null)
                {
                    parameters.Add(prop.Name, prop.GetValue(args, null));
                }
            }

            return parameters;
        }
    }
}
