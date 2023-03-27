using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class Function
    {
        public int IdFunctions { get; set; }
        public string NameFunctions { get; set; } = null!;
        public int AccessFunctions { get; set; }
        public byte[]? IconFunctions { get; set; }

        public virtual Role AccessFunctionsNavigation { get; set; } = null!;
    }
}
