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