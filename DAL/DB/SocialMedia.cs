using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DB
{
    [Table("SocialMedia")]
    public partial class SocialMedia
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [StringLength(50)]
        public string SocialMediaName { get; set; }

        public string SocialMediaLink { get; set; }
    }
}
