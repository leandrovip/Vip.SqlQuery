using System.ComponentModel;

namespace Vip.SqlQuery.Enums
{
    public enum Condition
    {
        [Description("=")] Equal,
        [Description(">")] Grater,
        [Description(">=")] GraterOrEqual,
        [Description("<")] Lower,
        [Description("<=")] LowerOrEqual,
        [Description("IN")] In,
        [Description("LIKE")] Like
    }
}