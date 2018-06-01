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
        public virtual DbSet<Uposlenici> Uposlenicis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Podnosilac>()
                .HasMany(e => e.Prijavas)
                .WithRequired(e => e.Podnosilac)
                .HasForeignKey(e => e.podnosilacPrijave_id);

            modelBuilder.Entity<Uposlenici>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<Uposlenici>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<Uposlenici>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<Uposlenici>()
                .Property(e => e.DatumRodjenja)
                .HasPrecision(3);
        }
    }
}
