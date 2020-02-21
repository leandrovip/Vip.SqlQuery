using Vip.SqlQuery.Utils;

namespace Vip.SqlQuery.Clause
{
    public class GroupByClause
    {
        #region Properties

        public string GroupByCommand { get; set; }

        #endregion

        #region Constructors

        public GroupByClause(string column)
        {
            CreateCommand(column);
        }

        #endregion

        #region Methods

        private void CreateCommand(string column)
        {
            GroupByCommand = Helper.ColumnName(column);
        }

        #endregion
    }
}