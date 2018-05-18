namespace Mieruka.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MierukaModel : DbContext
    {
        public MierukaModel()
            : base("name=MierukaConnectionString")
        {
        }

        public virtual DbSet<Mieruka.Models.MierukaView> MierukaView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
