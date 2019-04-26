namespace Vip.SqlQuery.Clause
{
    public class LimitClause
    {
        #region Propriedades

        public string LimitCommand { get; private set; }
        private int _rows;
        private readonly bool _percent;

        #endregion

        #region Construtores

        public LimitClause(int rows, bool percent)
        {
            _rows = rows;
            _percent = percent;

            CreateCommand();
        }

        #endregion

        #region Métodos

        private void CreateCommand()
        {
            if (_rows <= 0)
                _rows = 500;

            var percent = _percent ? " PERCENT" : "";

            LimitCommand = $"{_rows}{percent}";
        }

        #endregion
    }
}