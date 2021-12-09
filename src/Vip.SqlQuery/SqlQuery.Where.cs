using System.Linq;
using Vip.SqlQuery.Clause;
using Vip.SqlQuery.Enums;

namespace Vip.SqlQuery
{
    public partial class SqlQuery
    {
        #region Where

        public SqlQuery Where(string column, Condition condition, object value)
        {
            var logicOperator = _whereList.Any() ? LogicOperator.AND : LogicOperator.NULL;

            _whereList.Add(new WhereClause(column, condition, value, logicOperator, parameterNumber));
            parameterNumber++;
            return this;
        }

        public SqlQuery Where(bool predicate, string column, Condition condition, object value)
        {
            if (predicate)
            {
                var logicOperator = _whereList.Any() ? LogicOperator.AND : LogicOperator.NULL;
                _whereList.Add(new WhereClause(column, condition, value, logicOperator, parameterNumber));
                parameterNumber++;
            }

            return this;
        }

        public SqlQuery Where(Where[] multiple)
        {
            var logicOperator = _whereList.Any() ? LogicOperator.AND : LogicOperator.NULL;
            _whereList.Add(new WhereClause(multiple, logicOperator, parameterNumber));
            parameterNumber += multiple.Length;
            return this;
        }

        #endregion

        #region WhereAnd

        public SqlQuery WhereAnd(string column, Condition condition, object value)
        {
            _whereList.Add(new WhereClause(column, condition, value, LogicOperator.AND, parameterNumber));
            parameterNumber++;
            return this;
        }

        public SqlQuery WhereAnd(bool predicate, string column, Condition condition, object value)
        {
            if (predicate)
            {
                _whereList.Add(new WhereClause(column, condition, value, LogicOperator.AND, parameterNumber));
                parameterNumber++;
            }

            return this;
        }

        public SqlQuery WhereAnd(Where[] multiple)
        {
            _whereList.Add(new WhereClause(multiple, LogicOperator.AND, parameterNumber));
            parameterNumber += multiple.Length;
            return this;
        }

        #endregion

        #region WhereOr

        public SqlQuery WhereOr(string column, Condition condition, object value)
        {
            _whereList.Add(new WhereClause(column, condition, value, LogicOperator.OR, parameterNumber));
            parameterNumber++;
            return this;
        }

        public SqlQuery WhereOr(bool predicate, string column, Condition condition, object value)
        {
            if (predicate)
            {
                _whereList.Add(new WhereClause(column, condition, value, LogicOperator.OR, parameterNumber));
                parameterNumber++;
            }

            return this;
        }

        public SqlQuery WhereOr(Where[] multiple)
        {
            _whereList.Add(new WhereClause(multiple, LogicOperator.OR, parameterNumber));
            parameterNumber += multiple.Length;
            return this;
        }

        #endregion

        #region WhereBetween

        public SqlQuery WhereBetween(string column, object value1, object value2)
        {
            _whereList.Add(new WhereClause(column, value1, value2, parameterNumber));
            parameterNumber = +2;
            return this;
        }

        #endregion

        #region WhereCustom

        public SqlQuery WhereCustom(string column, string custom)
        {
            _whereList.Add(new WhereClause(column, custom));
            return this;
        }

        public SqlQuery WhereCustom(bool predicate, string column, string custom)
        {
            if (predicate)
                WhereCustom(column, custom);
            return this;
        }

        #endregion
    }
}