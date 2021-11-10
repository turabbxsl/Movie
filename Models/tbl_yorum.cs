namespace Filmsayt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_yorum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_yorum()
        {
            tbl_replies = new HashSet<tbl_replies>();
        }

        public int id { get; set; }

        [StringLength(500)]
        public string yorumicerik { get; set; }

        public int? yorumkullaniciid { get; set; }

        public int? yorumfilmid { get; set; }

        public DateTime? tarix { get; set; }

        [StringLength(50)]
        public string istifadeci { get; set; }

        public int? rayting { get; set; }

        public virtual tbl_kinolar tbl_kinolar { get; set; }

        public virtual tbl_kullanici tbl_kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_replies> tbl_replies { get; set; }
    }
}
