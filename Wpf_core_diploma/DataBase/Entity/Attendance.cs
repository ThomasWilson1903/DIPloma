﻿using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class Attendance
    {
        public int SectionSchedules { get; set; }
        public int Students { get; set; }
        public sbyte? PresenceMark { get; set; }
        public DateTime DateAttendance { get; set; }
        public int Idattendance { get; set; }

        public virtual SectionSchedule SectionSchedulesNavigation { get; set; } = null!;
        public virtual Student StudentsNavigation { get; set; } = null!;
    }
}
