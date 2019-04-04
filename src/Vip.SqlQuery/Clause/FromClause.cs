using Vip.SqlQuery.Utils;

namespace Vip.SqlQuery.Clause
{
    public class FromClause
    {
        #region Properties

        public string Table { get; private set; }

        #endregion

        #region Constructors

        public FromClause(string table)
        {
            Table = table;

            CreateCommand();
        }

        #endregion

        #region Methods

        private void CreateCommand()
        {
            Table = Helper.TableName(Table);
        }

        #endregion
    }
}