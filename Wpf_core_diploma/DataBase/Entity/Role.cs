using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string Names { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
