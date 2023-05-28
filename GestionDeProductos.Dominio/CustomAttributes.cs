using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeProductos.Domain
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class DbNameAttribute : Attribute
    {
        public string ColumnName { get; }
        public bool IsId { get; }

        public DbNameAttribute(string columnName = null, bool isId = false)
        {
            ColumnName = columnName;
            IsId = isId;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class DbTableNameAttribute : Attribute
    {
        public string TableName { get; }

        public DbTableNameAttribute(string tableName = null)
        {
            TableName = tableName;
        }
    }
}
