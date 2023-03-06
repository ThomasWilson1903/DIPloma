using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class StudentInfoParent
    {
        public int StudentParentsStudent { get; set; }
        public int StudentParentsParents { get; set; }

        public virtual Patronu StudentParentsParentsNavigation { get; set; } = null!;
        public virtual Student StudentParentsStudentNavigation { get; set; } = null!;
    }
}
