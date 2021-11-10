namespace Filmsayt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_kullanici()
        {
            tbl_replies = new HashSet<tbl_replies>();
            tbl_resm1 = new HashSet<tbl_resm>();
            tbl_yorum = new HashSet<tbl_yorum>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string adi { get; set; }

        [StringLength(50)]
        public string soyadi { get; set; }

        [StringLength(50)]
        public string istifadeciadi { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string sifre { get; set; }

        public DateTime? tarix { get; set; }

        public int? resmid { get; set; }

        [StringLength(13)]
        public string telefon { get; set; }

        [StringLength(50)]
        public string yenisifre { get; set; }

        [StringLength(50)]
        public string onaysifre { get; set; }

        public virtual tbl_resm tbl_resm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_replies> tbl_replies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_resm> tbl_resm1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_yorum> tbl_yorum { get; set; }
    }
}
