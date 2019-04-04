using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vip.SqlQuery.Extensions;
using Vip.SqlQuery.Utils;

namespace Vip.SqlQuery.Clause
{
    public class SelectClause
    {
        #region Properties

        public string Column { get; private set; }

        #endregion

        #region Constructor

        public SelectClause(string column)
        {
            CreateCommand(column);
        }

        public SelectClause(IEnumerable<string> columns, string prefix)
        {
            CreateCommand(columns, prefix);
        }

        #endregion

        #region Methods

        private void CreateCommand(string column)
        {
            Column = Helper.ColumnName(column);
        }

        private void CreateCommand(IEnumerable<string> columns, string prefix)
        {
            Column = columns.Aggregate(new StringBuilder(), (sb, x)
                    => (sb.Length == 0
                            ? sb
                            : sb.Append(", "))
                        .Append(!prefix.IsNullOrEmpty() ? $"[{prefix}]." : "")
                        .Append(Helper.ColumnName(x)))
                .ToString();
        }

        #endregion
    }
}