namespace DAL.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AboutMe")]
    public partial class AboutMe
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public string Header { get; set; }

        public string HeaderSecond { get; set; }

        public string ImagePath { get; set; }

        public string ImagePathSecond { get; set; }

        public string AboutComment { get; set; }
    }
}
