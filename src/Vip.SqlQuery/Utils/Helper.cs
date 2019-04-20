using Vip.SqlQuery.Extensions;

namespace Vip.SqlQuery.Utils
{
    public class Helper
    {
        public static string TableName(string table)
        {
            if (table.IsNullOrEmpty())
                return "";

            var values = table.Split(' ');

            return values.Length > 1 ? $"[{values[0]}] [{values[1]}]" : $"[{values[0]}]";
        }

        public static string ColumnName(string column)
        {
            string nameColumn;

            column = AjustPrefixAlias(column);
            if (column.Contains(" AS "))
            {
                var arrayColumn = column.Split(' ');
                nameColumn = $"{AjustWithDot(arrayColumn[0])} AS {arrayColumn[2]}";
            }
            else if (column.Contains("."))
            {
                nameColumn = AjustWithDot(column);
            }
            else
            {
                nameColumn = !column.IsNullOrEmpty() ? $"[{column}]" : "*";
            }

            return nameColumn;
        }

        private static string AjustWithDot(string column)
        {
            if (!column.Contains(".")) return $"[{column}]";

            var values = column.Split('.');
            return values.Length > 1 ? $"[{values[0]}].[{values[1]}]" : $"[{values[0]}]";
        }

        private static string AjustPrefixAlias(string column)
        {
            return column.Trim().Replace(" as ", " AS ").Replace(" As ", " AS ").Replace(" aS ", " AS ");
        }
    }
}