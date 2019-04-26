using Vip.SqlQuery.Clause;

namespace Vip.SqlQuery
{
    public partial class SqlQuery
    {
        #region Limit Clause

        public SqlQuery Limit(int rows, bool percent = false)
        {
            _limitClause = new LimitClause(rows, percent);
            return this;
        }

        #endregion
    }
}