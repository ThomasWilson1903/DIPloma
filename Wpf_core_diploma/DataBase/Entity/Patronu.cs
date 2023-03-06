using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class Patronu
    {
        public int IdinfoParents { get; set; }
        public string Names { get; set; } = null!;
        public string SurNames { get; set; } = null!;
        public string MiddleNames { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Gender { get; set; }

        public virtual Gender GenderNavigation { get; set; } = null!;
    }
}
