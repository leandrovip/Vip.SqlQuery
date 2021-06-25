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

        #region Join Clause Custom

        public SqlQuery InnerJoin(string custom)
        {
            _joinList.Add(new JoinClause(JoinType.InnerJoin, custom));
            return this;
        }

        public SqlQuery LeftJoin(string custom)
        {
            _joinList.Add(new JoinClause(JoinType.LeftJoin, custom));
            return this;
        }

        public SqlQuery RightJoin(string custom)
        {
            _joinList.Add(new JoinClause(JoinType.RightJoin, custom));
            return this;
        }

        public SqlQuery CrossApply(string custom)
        {
            _joinList.Add(new JoinClause(JoinType.CrossApply, custom));
            return this;
        }

        public SqlQuery OuterApply(string custom)
        {
            _joinList.Add(new JoinClause(JoinType.OuterApply, custom));
            return this;
        }

        #endregion
    }
}