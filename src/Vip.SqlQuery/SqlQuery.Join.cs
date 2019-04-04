using Vip.SqlQuery.Clause;
using Vip.SqlQuery.Enums;

namespace Vip.SqlQuery
{
    public partial class SqlQuery
    {
        #region Join Clause

        public SqlQuery InnerJoin(string table, string firtColumn, Condition condition, string secondColumn)
        {
            _joinList.Add(new JoinClause(JoinType.InnerJoin, table, firtColumn, condition, secondColumn));
            return this;
        }

        public SqlQuery LeftJoin(string table, string firtColumn, Condition condition, string secondColumn)
        {
            _joinList.Add(new JoinClause(JoinType.LeftJoin, table, firtColumn, condition, secondColumn));
            return this;
        }

        public SqlQuery RightJoin(string table, string firtColumn, Condition condition, string secondColumn)
        {
            _joinList.Add(new JoinClause(JoinType.RightJoin, table, firtColumn, condition, secondColumn));
            return this;
        }

        #endregion
    }
}