using System;
using System.Collections.Generic;

namespace DataBase.DIPloma.Entity
{
    public partial class Journal
    {
        public int Idjournal { get; set; }
        public int ListItems { get; set; }
        public int Students { get; set; }
        public int? Aestimatio { get; set; }
        public string? Comment { get; set; }

        public virtual ListItem ListItemsNavigation { get; set; } = null!;
        public virtual Student StudentsNavigation { get; set; } = null!;
    }
}
