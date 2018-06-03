namespace AmbasadaAPI.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prijava")]
    public partial class Prijava
    {
        public int id { get; set; }

        public DateTime vrijemePrijave { get; set; }

        public bool stanjePrijave { get; set; }

        public virtual Podnosilac Podnosilac { get; set; }
    }
}
