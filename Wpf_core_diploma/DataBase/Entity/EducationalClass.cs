using System;
using System.Collections.Generic;

namespace DataBase.DIPloma.Entity
{
    public partial class EducationalClass
    {
        public EducationalClass()
        {
            Students = new HashSet<Student>();
        }

        public int Idgroup { get; set; }
        public string? ClassNumber { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
