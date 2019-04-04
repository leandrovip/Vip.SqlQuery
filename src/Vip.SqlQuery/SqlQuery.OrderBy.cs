using System.Linq;
using Vip.SqlQuery.Clause;
using Vip.SqlQuery.Enums;

namespace Vip.SqlQuery
{
    public partial class SqlQuery
    {
        #region OrderBy Clause  

        public SqlQuery OrderBy(string column)
        {
            _orderByList.Add(new OrderByClause(column));
            return this;
        }

        public SqlQuery OrderByDesc(string column)
        {
            _orderByList.Add(new OrderByClause(column, Sorting.Desc));
            return this;
        }

        public SqlQuery OrderByAsc(string column)
        {
            _orderByList.Add(new OrderByClause(column, Sorting.Asc));
            return this;
        }

        public SqlQuery OrderBy(string[] columns)
        {
            _orderByList.AddRange(columns.Select(x => new OrderByClause(x)));
            return this;
        }

        #endregion
    }
}