using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DB
{
    [Table("Education")]
    public partial class Education
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        [StringLength(15)]
        public string Year { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }
    }
}
