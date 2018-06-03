namespace AmbasadaAPI.NET.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AmbasadaModel : DbContext
    {
        public AmbasadaModel()
            : base("name=AmbasadaModelConnection")
        {
        }

        public virtual DbSet<Podnosilac> Podnosilacs { get; set; }
        public virtual DbSet<Prijava> Prijavas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Podnosilac>()
                .HasRequired(e => e.Prijava)
                .WithRequiredPrincipal(e => e.Podnosilac);

        

        }
    }
}
