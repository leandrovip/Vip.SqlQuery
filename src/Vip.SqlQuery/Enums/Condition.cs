using System.ComponentModel;

namespace Vip.SqlQuery.Enums
{
    public enum Condition
    {
        [Description("=")] Equal = 0,
        [Description("<>")] NotEqual = 7,
        [Description(">")] Grater = 1,
        [Description(">=")] GraterOrEqual = 2,
        [Description("<")] Lower = 3,
        [Description("<=")] LowerOrEqual =4,
        [Description("IN")] In =5,
        [Description("LIKE")] Like = 6
    }
}