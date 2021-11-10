namespace Filmsayt.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_resm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_resm()
        {
            tbl_kinolar = new HashSet<tbl_kinolar>();
            tbl_kullanici = new HashSet<tbl_kullanici>();
        }

        public int id { get; set; }

        [StringLength(500)]
        public string kicikolculu { get; set; }

        [StringLength(500)]
        public string ortaolculu { get; set; }

        [StringLength(500)]
        public string boyukolculu { get; set; }

        public int? filmid { get; set; }

        public bool? varsayilan { get; set; }

        public int? kullaniciid { get; set; }

        [StringLength(500)]
        public string kullaniciolculu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_kinolar> tbl_kinolar { get; set; }

        public virtual tbl_kinolar tbl_kinolar1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_kullanici> tbl_kullanici { get; set; }

        public virtual tbl_kullanici tbl_kullanici1 { get; set; }
    }
}
