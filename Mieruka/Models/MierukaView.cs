namespace Mieruka.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MierukaView")]
    public partial class MierukaView
    {
        [Key]
        public int MachineNumber { get; set; }

        public int Plan { get; set; }

        public DateTime Date { get; set; }

        public int ActualCount { get; set; }

        public int Unit { get; set; }
    }
}
