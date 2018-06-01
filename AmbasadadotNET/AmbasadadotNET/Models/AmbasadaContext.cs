using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AmbasadadotNET.Models
{
    public class AmbasadaContext: DbContext
    {
        public AmbasadaContext() : base("AzureBaza") {
           // AutomaticMigrationsEnabled = true;
        }
        public DbSet<Prijava> prijave { get; set; }
        public DbSet<Podnosilac> podnosioci { get; set; } 
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        */
    }
}