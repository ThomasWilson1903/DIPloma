using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            Journals = new HashSet<Journal>();
        }

        public int Idstudents { get; set; }
        public string NameStudent { get; set; } = null!;
        public string SurnameStudent { get; set; } = null!;
        public string MiddleNameStudent { get; set; } = null!;
        public int Group { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual EducationalClass GroupNavigation { get; set; } = null!;
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
