using System;
using System.Collections.Generic;

namespace DataBase.DIPloma.Entity
{
    public partial class Section
    {
        public Section()
        {
            SectionSchedules = new HashSet<SectionSchedule>();
        }

        public int Idsections { get; set; }
        public int Teachers { get; set; }
        public string? NameSection { get; set; }

        public virtual Teacher TeachersNavigation { get; set; } = null!;
        public virtual ICollection<SectionSchedule> SectionSchedules { get; set; }
    }
}
