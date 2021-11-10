namespace Filmsayt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_replies
    {
        public int id { get; set; }

        [StringLength(500)]
        public string text { get; set; }

        public int? commentid { get; set; }

        [Column(TypeName = "date")]
        public DateTime? tarix { get; set; }

        public int? userid { get; set; }

        public virtual tbl_kullanici tbl_kullanici { get; set; }

        public virtual tbl_yorum tbl_yorum { get; set; }
    }
}
