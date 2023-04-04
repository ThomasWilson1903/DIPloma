using System;
using System.Collections.Generic;

namespace DIPloma.DataBase.Entity
{
    public partial class DataTimeRecord
    {
        public DataTimeRecord()
        {
            Journals = new HashSet<Journal>();
        }

        public int IdDataTimeRecord { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly? Time { get; set; }

        public virtual ICollection<Journal> Journals { get; set; }
    }
}
