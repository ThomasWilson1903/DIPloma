﻿using System;
using System.Collections.Generic;

namespace DataBase.DIPloma.Entity
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
        public string MiddleNameTeacher { get; set; } = null!;

        public virtual ICollection<ListItem> ListItems { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
