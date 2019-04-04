using Vip.SqlQuery.Enums;
using Vip.SqlQuery.Extensions;
using Vip.SqlQuery.Utils;

namespace Vip.SqlQuery.Clause
{
    public class JoinClause
    {
        #region Properties

        public string JoinCommand { get; private set; }

        #endregion

        #region Constructor

        public JoinClause(JoinType type, string table, string first, Condition condition, string second)
        {
            CreateCommand(type, table, first, condition, second);
        }

        #endregion

        #region Methods

        private void CreateCommand(JoinType type, string table, string first, Condition condition, string second)
        {
            var typeName = type.GetDescription();
            var tableName = Helper.TableName(table);
            var firstName = Helper.ColumnName(first);
            var secondName = Helper.ColumnName(second);

            JoinCommand = $"{typeName} {tableName} ON {firstName} {condition.GetDescription()} {secondName}";
        }

        #endregion
    }
}