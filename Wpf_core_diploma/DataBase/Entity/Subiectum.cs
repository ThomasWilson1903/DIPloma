using System;
using System.Collections.Generic;

namespace DataBase.DIPloma.Entity
{
    public partial class Subiectum
    {
        public Subiectum()
        {
            ListItems = new HashSet<ListItem>();
        }

        public int Idobjects { get; set; }
        public string NameSubiectum { get; set; } = null!;

        public virtual ICollection<ListItem> ListItems { get; set; }
    }
}
