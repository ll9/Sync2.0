using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Extensions
{
    public static class TypeExtension
    {
        public static string GetSqlType(this Type type)
        {
            if (type == typeof(DateTime))
            {
                return "DATETIME";
            }
            else if (type == typeof(double))
            {
                return "DOUBLE";
            }
            else
            {
                return "TEXT";
            }
        }
    }
}
