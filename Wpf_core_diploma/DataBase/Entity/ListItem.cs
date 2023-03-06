using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class ListItem
    {
        public ListItem()
        {
            Journals = new HashSet<Journal>();
        }

        public int Idschedule { get; set; }
        public int Subiectum { get; set; }
        public int Users { get; set; }
        public int Teachers { get; set; }

        public virtual Subiectum SubiectumNavigation { get; set; } = null!;
        public virtual Teacher TeachersNavigation { get; set; } = null!;
        public virtual User UsersNavigation { get; set; } = null!;
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
