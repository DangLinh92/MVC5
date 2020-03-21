namespace QuanLyVanBan.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLVanBanModel : DbContext
    {
        public QLVanBanModel()
            : base("name=QLVanBanModelEntity")
        {
        }

        public virtual DbSet<stanfDonVi> stanfDonVis { get; set; }
        public virtual DbSet<stanfLoaiVanBan> stanfLoaiVanBans { get; set; }
        public virtual DbSet<stanfVanBan> stanfVanBans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<stanfDonVi>()
                .Property(e => e.DienThoai)
                .IsFixedLength();

            modelBuilder.Entity<stanfDonVi>()
                .HasMany(e => e.stanfVanBans)
                .WithOptional(e => e.stanfDonVi)
                .HasForeignKey(e => e.DonViId);

            modelBuilder.Entity<stanfLoaiVanBan>()
                .HasMany(e => e.stanfVanBans)
                .WithOptional(e => e.stanfLoaiVanBan)
                .HasForeignKey(e => e.LoaiVanBanId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<stanfVanBan>()
                .Property(e => e.DinhDang)
                .IsFixedLength();
        }
    }
}
