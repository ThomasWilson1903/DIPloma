using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class DayWeek
    {
        public DayWeek()
        {
            SectionSchedules = new HashSet<SectionSchedule>();
        }

        public int IdDayWeek { get; set; }
        public string NameDayWeek { get; set; } = null!;

        public virtual ICollection<SectionSchedule> SectionSchedules { get; set; }
    }
}
