﻿using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class User
    {
        public User()
        {
            ListItems = new HashSet<ListItem>();
            Sections = new HashSet<Section>();
        }

        public int IdUserss { get; set; }
        public string Mail { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }
        public string NameUser { get; set; } = null!;
        public string SurNameUser { get; set; } = null!;
        public string DobleNameUser { get; set; } = null!;
        public byte[]? PhotoUsers { get; set; }

        public virtual Role RoleNavigation { get; set; } = null!;
        public virtual ICollection<ListItem> ListItems { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
