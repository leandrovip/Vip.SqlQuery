using System.Collections.Generic;
using System.Linq;
using Vip.SqlQuery.Clause;

namespace Vip.SqlQuery.Extensions
{
    public static class CompileExtensions
    {
        public static string CompileSelects(this IEnumerable<SelectClause> list)
        {
            var select = string.Join(", ", list.Select(x => x.Column).ToList());
            return !select.IsNullOrEmpty() ? $"SELECT {select}" : "";
        }

        public static string CompileFrom(this FromClause from)
        {
            return from != null ? $"FROM {from.Table}" : "";
        }

        public static string CompileWheres(this IEnumerable<WhereClause> list)
        {
            var where = string.Join(" ", list.Select(x => x.WhereCondition));
            return !where.IsNullOrEmpty() ? $"WHERE {where}" : "";
        }

        public static string CompileJoins(this IEnumerable<JoinClause> list)
        {
            var join = string.Join(" ", list.Select(x => x.JoinCommand));
            return !join.IsNullOrEmpty() ? join : "";
        }

        public static string CompileOrderBy(this List<OrderByClause> list)
        {
            var orderBy = string.Join(", ", list.Select(x => x.OrderByCommand));
            return !orderBy.IsNullOrEmpty() ? $"ORDER BY {orderBy}" : "";
        }
    }
}