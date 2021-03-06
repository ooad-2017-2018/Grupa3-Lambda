namespace AmbasadaAPI.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Podnosilac")]
    public partial class Podnosilac
    {

        public int id { get; set; }

        [Required]
        public string naziv { get; set; }

        [Required]
        public string email { get; set; }

        public DateTime datumRodjenja { get; set; }

        [Required]
        public string jmbg { get; set; }

        public string dodatneInformacije { get; set; }

        [Required]
        public string mjestoPrebivalista { get; set; }

        public Prijava Prijava { get; set; }
    }
}
