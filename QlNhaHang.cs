using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTL_Nhom11
{
    public partial class QlNhaHang : DbContext
    {
        public QlNhaHang()
            : base("name=QlNhaHang")
        {
        }

        public virtual DbSet<Ban> Bans { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<Menu_SanPham> Menu_SanPham { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.Ban)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sdt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.KhachHang)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.ma_km)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.NhanVien)
                .WillCascadeOnDelete();
        }
    }
}
