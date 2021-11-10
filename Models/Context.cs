namespace Filmsayt.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context24")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_kategoriya> tbl_kategoriya { get; set; }
        public virtual DbSet<tbl_kinolar> tbl_kinolar { get; set; }
        public virtual DbSet<tbl_kullanici> tbl_kullanici { get; set; }
        public virtual DbSet<tbl_resm> tbl_resm { get; set; }
        public virtual DbSet<tbl_yorum> tbl_yorum { get; set; }
        public virtual DbSet<tbl_replies> tbl_replies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_kategoriya>()
                .HasMany(e => e.tbl_kinolar)
                .WithOptional(e => e.tbl_kategoriya)
                .HasForeignKey(e => e.kategoriyaid);

            modelBuilder.Entity<tbl_kinolar>()
                .Property(e => e.reyting)
                .HasPrecision(18, 1);

            modelBuilder.Entity<tbl_kinolar>()
                .HasMany(e => e.tbl_resm1)
                .WithOptional(e => e.tbl_kinolar1)
                .HasForeignKey(e => e.filmid);

            modelBuilder.Entity<tbl_kinolar>()
                .HasMany(e => e.tbl_yorum)
                .WithOptional(e => e.tbl_kinolar)
                .HasForeignKey(e => e.yorumfilmid);

            modelBuilder.Entity<tbl_kullanici>()
                .Property(e => e.telefon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_kullanici>()
                .HasMany(e => e.tbl_replies)
                .WithOptional(e => e.tbl_kullanici)
                .HasForeignKey(e => e.userid);

            modelBuilder.Entity<tbl_kullanici>()
                .HasMany(e => e.tbl_resm1)
                .WithOptional(e => e.tbl_kullanici1)
                .HasForeignKey(e => e.kullaniciid);

            modelBuilder.Entity<tbl_kullanici>()
                .HasMany(e => e.tbl_yorum)
                .WithOptional(e => e.tbl_kullanici)
                .HasForeignKey(e => e.yorumkullaniciid);

            modelBuilder.Entity<tbl_resm>()
                .HasMany(e => e.tbl_kinolar)
                .WithOptional(e => e.tbl_resm)
                .HasForeignKey(e => e.resmid);

            modelBuilder.Entity<tbl_resm>()
                .HasMany(e => e.tbl_kullanici)
                .WithOptional(e => e.tbl_resm)
                .HasForeignKey(e => e.resmid);

            modelBuilder.Entity<tbl_yorum>()
                .HasMany(e => e.tbl_replies)
                .WithOptional(e => e.tbl_yorum)
                .HasForeignKey(e => e.commentid);
        }
    }
}
