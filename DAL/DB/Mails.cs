namespace DAL.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mails
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        public string SendFromName { get; set; }

        public string SendFromEmailAdress { get; set; }

        public string SendFromIp { get; set; }

        public string Message { get; set; }

        public DateTime? SendDate { get; set; }
    }
}
