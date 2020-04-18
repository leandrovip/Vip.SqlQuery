using System.Collections.Generic;
using Vip.SqlQuery.Enums;
using Vip.SqlQuery.Extensions;
using Vip.SqlQuery.Utils;

namespace Vip.SqlQuery.Clause
{
    public class WhereClause
    {
        #region Properties

        public string WhereCondition { get; private set; }
        public List<Parameter> Parameter { get; set; }

        #endregion

        #region Constructors

        public WhereClause(string column, Condition condition, object value, LogicOperator logicOperator,
            int parameterNumber) : this()
        {
            CreateCommand(column, condition, value, logicOperator, parameterNumber);
        }

        public WhereClause(IEnumerable<Where> wheres, LogicOperator logicOperator,
            int parameterNumber) : this()
        {
            CreateCommand(wheres, logicOperator, parameterNumber);
        }

        public WhereClause(string column, object value1, object value2, int parameterNumber) : this()
        {
            CreateCommand(column, value1, value2, parameterNumber);
        }

        public WhereClause(string column, string customWhere)
        {
            CreateCommand(column, customWhere);
        }

        private WhereClause()
        {
            Parameter = new List<Parameter>();
        }

        #endregion

        #region Methods

        private void CreateCommand(string column, Condition condition, object value, LogicOperator logicOperator,
            int parameterNumber)
        {
            var columnName = Helper.ColumnName(column);
            var parameterName = $"@p{parameterNumber}";
            var logic = logicOperator == LogicOperator.NULL ? "" : logicOperator.GetDescription() + " ";

            WhereCondition = $"{logic}{columnName} {condition.GetDescription()} {parameterName}";
            Parameter.Add(new Parameter {Name = parameterName, Value = value});
        }

        private void CreateCommand(IEnumerable<Where> wheres, LogicOperator logicOperator,
            int parameterNumber)
        {
            var command = logicOperator == LogicOperator.NULL ? "(" : logicOperator.GetDescription() + " (";

            foreach (var item in wheres)
            {
                CreateCommand(item.Column, item.Condition, item.Value, item.LogicOperator, parameterNumber);
                command += (item.LogicOperator == LogicOperator.NULL ? "" : " ") + WhereCondition;
                parameterNumber++;
            }

            WhereCondition = command + ")";
        }

        private void CreateCommand(string column, object value1, object value2, int parameterNumber)
        {
            var columnName = Helper.ColumnName(column);
            var parameterName1 = $"@p{parameterNumber}";
            var parameterName2 = $"@p{parameterNumber + 1}";

            WhereCondition = $"{columnName} BETWEEN {parameterName1} AND {parameterName2}";
            Parameter.Add(new Parameter {Name = parameterName1, Value = value1});
            Parameter.Add(new Parameter {Name = parameterName2, Value = value2});
        }

        private void CreateCommand(string column, string customWhere)
        {
            var columnName = Helper.ColumnName(column);
            var custom = customWhere.Trim();

            WhereCondition = $"{columnName} {custom}";
        }

        #endregion
    }

    public class Where
    {
        #region Properties

        public string Column { get; set; }
        public Condition Condition { get; set; }
        public object Value { get; set; }
        public LogicOperator LogicOperator { get; set; }

        #endregion

        #region Constructor

        public Where(string column, Condition condition, object value,
            LogicOperator logicOperator = LogicOperator.NULL)
        {
            Column = column;
            Condition = condition;
            Value = value;
            LogicOperator = logicOperator;
        }

        #endregion
    }
}