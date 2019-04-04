using Vip.SqlQuery.Enums;
using Vip.SqlQuery.Extensions;
using Vip.SqlQuery.Utils;

namespace Vip.SqlQuery.Clause
{
    public class OrderByClause
    {
        #region Properties

        public string OrderByCommand { get; private set; }

        private readonly string _column;
        private readonly Sorting _sort;

        #endregion

        #region Constructor

        public OrderByClause(string column, Sorting sort = Sorting.NULL)
        {
            _column = column;
            _sort = sort;

            CreateCommand();
        }

        #endregion

        #region Methods

        private void CreateCommand()
        {
            var column = Helper.ColumnName(_column);
            var sort = _sort == Sorting.NULL ? "" : " " + _sort.GetDescription();

            OrderByCommand = $"{column}{sort}";
        }

        #endregion
    }
}