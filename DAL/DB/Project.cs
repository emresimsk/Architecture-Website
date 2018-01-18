namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public string ProjectNameUnique { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Comment { get; set; }

        public string TitleSecond { get; set; }

        public string CommentSecond { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public string MainPicturePath { get; set; }
    }
}
