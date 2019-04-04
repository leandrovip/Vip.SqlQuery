using System.Collections.Generic;
using System.Linq;
using Vip.SqlQuery.Clause;
using Vip.SqlQuery.Extensions;

namespace Vip.SqlQuery
{
    public partial class SqlQuery
    {
        #region Properties

        private readonly List<SelectClause> _selectList;
        private readonly List<WhereClause> _whereList;
        private readonly List<JoinClause> _joinList;
        private readonly List<OrderByClause> _orderByList;
        private FromClause _fromClause;

        private int parameterNumber;

        #endregion

        #region Constructors

        private SqlQuery()
        {
            _selectList = new List<SelectClause>();
            _whereList = new List<WhereClause>();
            _joinList = new List<JoinClause>();
            _orderByList = new List<OrderByClause>();

            parameterNumber = 0;
        }

        #endregion

        #region Methods

        public SqlResult Build()
        {
            var results = new[]
            {
                _selectList.CompileSelects(),
                _fromClause.CompileFrom(),
                _joinList.CompileJoins(),
                _whereList.CompileWheres(),
                _orderByList.CompileOrderBy()
            };

            var sql = string.Join(" ", results.Where(x => !x.IsNullOrEmpty()));
            var parameters = _whereList.SelectMany(x => x.Parameter).Distinct().ToArray();

            return new SqlResult {Command = sql, Parameters = parameters};
        }

        #endregion

        #region Method Statics

        public static SqlQuery New()
        {
            return new SqlQuery();
        }

        #endregion
    }
}