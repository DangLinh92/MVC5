namespace BookStoreAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookStoreModel : DbContext
    {
        public BookStoreModel()
            : base("name=BookStoresModel")
        {
        }

        public virtual DbSet<ChuDe> ChuDes { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<Sache> Saches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuDe>()
                .Property(e => e.MaChuDe)
                .IsUnicode(false);

            modelBuilder.Entity<ChuDe>()
                .HasMany(e => e.Saches)
                .WithOptional(e => e.ChuDe)
                .HasForeignKey(e => e.ChuDeId);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Sache>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<Sache>()
                .Property(e => e.ChuDeId)
                .IsUnicode(false);
        }
    }
}
