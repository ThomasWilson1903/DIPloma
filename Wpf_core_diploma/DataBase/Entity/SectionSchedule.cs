using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class SectionSchedule
    {
        public SectionSchedule()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int IdsectionSchedules { get; set; }
        public int Sections { get; set; }
        public int IdDayWeek { get; set; }
        public TimeOnly TimeSpending { get; set; }

        public virtual DayWeek IdDayWeekNavigation { get; set; } = null!;
        public virtual Section SectionsNavigation { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
