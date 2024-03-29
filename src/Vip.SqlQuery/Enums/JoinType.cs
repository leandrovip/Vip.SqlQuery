﻿using System.ComponentModel;

namespace Vip.SqlQuery.Enums
{
    public enum JoinType
    {
        [Description("INNER JOIN")] InnerJoin,
        [Description("LEFT JOIN")] LeftJoin,
        [Description("RIGHT JOIN")] RightJoin,
        [Description("CROSS APPLY")] CrossApply,
        [Description("OUTER APPLY")] OuterApply,
    }
}