using System.Linq;
using Vip.SqlQuery.Clause;

namespace Vip.SqlQuery
{
    public partial class SqlQuery
    {
        public SqlQuery GroupBy(string column)
        {
            _groupByList.Add(new GroupByClause(column));
            return this;
        }

        public SqlQuery GroupBy(string[] columns)
        {
            _groupByList.AddRange(columns.Select(x => new GroupByClause(x)));
            return this;
        }
    }
}