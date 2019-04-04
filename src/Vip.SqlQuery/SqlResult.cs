using Vip.SqlQuery.Utils;

namespace Vip.SqlQuery
{
    public class SqlResult
    {
        public string Command { get; set; }
        public Parameter[] Parameters { get; set; }
    }
}