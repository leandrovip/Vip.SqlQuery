using System.Collections.Generic;
using System.Linq;
using Vip.SqlQuery.Extensions;

namespace Vip.SqlQuery.Utils
{
    public class Helper
    {
        private static readonly List<string> _functions = new List<string>
        {
            "COUNT", "AVG", "DISTINCT", "SUM", "MAX", "MIN", "ABS", "ROUND",
            "CAST", "CONVERT", "PARSE", "GETDATE", "DAY", "MONTH", "YEAR", "ISDATE", "SELECT", "ISNULL"
        };

        public static string TableName(string table)
        {
            if (table.IsNullOrEmpty())
                return "";

            var values = table.Split(' ');

            return values.Length > 1 ? $"[{values[0]}] [{values[1]}]" : $"[{values[0]}]";
        }

        public static string ColumnName(string column)
        {
            return _functions.Any(column.ToUpper().Contains) ? BuildFunctions(column) : BuildColumnName(column);
        }

        private static string BuildColumnName(string column)
        {
            string nameColumn;

            column = BuildPrefixAlias(column);
            if (column.Contains(" AS "))
            {
                var arrayColumn = column.Split(' ');
                nameColumn = $"{BuildColumnDot(arrayColumn[0])} AS {arrayColumn[2]}";
            }
            else if (column.Contains("."))
            {
                nameColumn = BuildColumnDot(column);
            }
            else
            {
                nameColumn = !column.IsNullOrEmpty() ? $"[{column}]" : "*";
            }

            return nameColumn;
        }

        private static string BuildFunctions(string function)
        {
            return BuildPrefixAlias(function);
        }

        private static string BuildColumnDot(string column)
        {
            if (!column.Contains(".")) return $"[{column}]";

            var values = column.Split('.');
            return values.Length > 1 ? $"[{values[0]}].[{values[1]}]" : $"[{values[0]}]";
        }

        private static string BuildPrefixAlias(string column)
        {
            return column.Trim().Replace(" as ", " AS ").Replace(" As ", " AS ").Replace(" aS ", " AS ");
        }
    }
}