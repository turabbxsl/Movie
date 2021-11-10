namespace Filmsayt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_kinolar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_kinolar()
        {
            tbl_resm1 = new HashSet<tbl_resm>();
            tbl_yorum = new HashSet<tbl_yorum>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string kinoadi { get; set; }

        public string kinoaciqlama { get; set; }

        public int? kategoriyaid { get; set; }

        [StringLength(500)]
        public string oyuncuadi { get; set; }

        [StringLength(50)]
        public string yonetmenadi { get; set; }

        public DateTime? tarix { get; set; }

        public decimal? reyting { get; set; }

        public int? resmid { get; set; }

        public int? goruntulenme { get; set; }

        public int? begen { get; set; }

        public int? begenme { get; set; }

        public virtual tbl_kategoriya tbl_kategoriya { get; set; }

        public virtual tbl_resm tbl_resm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_resm> tbl_resm1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_yorum> tbl_yorum { get; set; }
    }
}
