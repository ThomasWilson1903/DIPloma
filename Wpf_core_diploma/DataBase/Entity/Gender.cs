using System;
using System.Collections.Generic;

namespace DataBase.DIPloma.Entity
{
    public partial class Gender
    {
        public Gender()
        {
            Patronus = new HashSet<Patronu>();
        }

        public int Idgender { get; set; }
        public string Names { get; set; } = null!;

        public virtual ICollection<Patronu> Patronus { get; set; }
    }
}
