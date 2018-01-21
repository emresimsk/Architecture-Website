using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DB
{
    [Table("ContactPage")]
    public partial class ContactPage
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public string ImagePath { get; set; }
    }
}
