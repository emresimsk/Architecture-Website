using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DB
{
    [Table("ImageFilePath")]
    public partial class ImageFilePath
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ProjectID { get; set; }

        public string ImagePath { get; set; }
    }
}
