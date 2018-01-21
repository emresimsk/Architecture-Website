using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DB
{
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
