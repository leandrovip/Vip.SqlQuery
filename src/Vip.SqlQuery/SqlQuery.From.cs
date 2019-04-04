using Vip.SqlQuery.Clause;

namespace Vip.SqlQuery
{
    public partial class SqlQuery
    {
        #region From Clause

        public SqlQuery From(string table)
        {
            _fromClause = new FromClause(table);
            return this;
        }

        #endregion
    }
}