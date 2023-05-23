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

namespace GestionDeProductos.DataAccess.Repository.Sql
{
    /// <summary>
    /// Clase abstracta que contiene la implementacion necesaria para el tratamiento de repositorios.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAdapter"></typeparam>
    public abstract class SqlRepository<T>
        where T : Entity, new()
    {
        public abstract string DeleteQuery { get; }
        public abstract string SelectAllQuery { get; }
        public abstract string SelectQuery { get; }
        public abstract string InsertQuery { get; }
        public abstract string UpdateQuery { get; }

        private static string connString { get => Environment.GetEnvironmentVariable("mssql_connstring"); }


        /// <summary>
        /// Constructor por defecto para el funcionamiento basico de todas las querys.
        /// </summary>
        public SqlRepository()
        {
        }

        /// <summary>
        /// Borra un objeto.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual async Task<int> Delete(object parameters, string queryOverride = "")
        {
            try
            {
                var query = DeleteQuery;
                if (queryOverride != null && queryOverride != "")
                    query = queryOverride;


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
        /// Obtiene todos los objetos.
        /// </summary>
        /// <param name="paramss"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAll(object parameters = null, string queryOverride = "")
        {
            var query = SelectAllQuery;
            if (queryOverride != null && queryOverride != "")
                query = queryOverride;


            //Using the dynamic parameters like usual
            using (var con = new SqlConnection(connString))
            {
                var results = await con.QueryAsync<T>(query, GetParameters(parameters, query));
                return results;
            }   
        }

        /// <summary>
        /// Obtiene un objeto.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual async Task<T> GetOne(object parameters, string queryOverride = "")
        {
            try
            {
                var query = SelectQuery;
                if (queryOverride != null && queryOverride != "")
                    query = queryOverride;

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
        /// Inserta un objeto.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual async Task<int> Insert(object parameters, string queryOverride = "")
        {
            try
            {
                var query = InsertQuery;
                if (queryOverride != null && queryOverride != "")
                    query = queryOverride;

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
        /// Actualiza un objeto.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="queryOverride"></param>
        /// <returns></returns>
        public virtual async Task<int> Update(object parameters, string queryOverride = "")
        {
            try
            {
                var query = UpdateQuery;
                if (queryOverride != null && queryOverride != "")
                    query = queryOverride;

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
        /// Obtiene un array de SqlParameter a partir de las propiedades del objeto especificado mientras se filtra por una query.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetParameters(object args, string query)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            Type myType = args.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());


            foreach (PropertyInfo prop in props)
            {
                var value = prop.GetValue(args, null);
                if (query.Contains(prop.Name) && value != null)
                {
                    parameters.Add(prop.Name, prop.GetValue(args, null));
                }
            }

            return parameters;
        }
    }
}
