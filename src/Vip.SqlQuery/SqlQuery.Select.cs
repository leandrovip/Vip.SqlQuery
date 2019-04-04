using Vip.SqlQuery.Clause;

namespace Vip.SqlQuery
{
    public partial class SqlQuery
    {
        #region Select Clause

        public SqlQuery Select(string column = "")
        {
            _selectList.Add(new SelectClause(column));
            return this;
        }

        public SqlQuery Select(string[] columns, string prefix = "")
        {
            _selectList.Add(new SelectClause(columns, prefix));
            return this;
        }

        #endregion
    }
}