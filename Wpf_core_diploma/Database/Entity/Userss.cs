using System;
using System.Collections.Generic;

namespace Wpf_core_diploma.Database.Entity
{
    public partial class Userss
    {
        public int IdUserss { get; set; }
        public string Mail { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
