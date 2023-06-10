using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class Teacher
    {
        public Teacher()
        {
            ListItems = new HashSet<ListItem>();
            Sections = new HashSet<Section>();
        }

        public int IdTeachers { get; set; }
        public string NameTeacher { get; set; } = null!;
        public string SurnameTeacher { get; set; } = null!;
        public string? MiddleNameTeacher { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime DateBirth { get; set; }
        public DateTime DateWork { get; set; }
        public int? OfficeNumber { get; set; }
        public byte[]? PhotoTeachers { get; set; }

        public virtual ICollection<ListItem> ListItems { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
