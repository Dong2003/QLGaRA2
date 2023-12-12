using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Entity
{
    public partial class GaraotoDbContext : DbContext
    {
        public GaraotoDbContext()
            : base("name=GaraotoDbContext")
        {
        }

        public virtual DbSet<ChiTietDoanhThu> ChiTietDoanhThus { get; set; }
        public virtual DbSet<ChiTietSuaChua> ChiTietSuaChuas { get; set; }
        public virtual DbSet<ChiTietUser> ChiTietUsers { get; set; }
        public virtual DbSet<ChoPhepSuDungQuyen> ChoPhepSuDungQuyens { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CTNhapKho> CTNhapKhoes { get; set; }
        public virtual DbSet<CTTonKho> CTTonKhoes { get; set; }
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhapKho> NhapKhoes { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<SuaChua> SuaChuas { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThuongHieuXe> ThuongHieuXes { get; set; }
        public virtual DbSet<TienCong> TienCongs { get; set; }
        public virtual DbSet<TiepNhanXe> TiepNhanXes { get; set; }
        public virtual DbSet<TonKho> TonKhoes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VatTu> VatTus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.ChoPhepSuDungQuyens)
                .WithOptional(e => e.ChucVu)
                .HasForeignKey(e => e.IDChucVu);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.ChucVu)
                .HasForeignKey(e => e.IDChucVu);

            modelBuilder.Entity<DoanhThu>()
                .Property(e => e.DoanhThu1)
                .IsFixedLength();

            modelBuilder.Entity<NhapKho>()
                .HasMany(e => e.CTNhapKhoes)
                .WithRequired(e => e.NhapKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuaChua>()
                .HasMany(e => e.ChiTietSuaChuas)
                .WithOptional(e => e.SuaChua)
                .HasForeignKey(e => e.IDMaSuaChu);

            modelBuilder.Entity<ThuongHieuXe>()
                .Property(e => e.ANh)
                .IsUnicode(false);

            modelBuilder.Entity<ThuongHieuXe>()
                .HasMany(e => e.ChiTietDoanhThus)
                .WithRequired(e => e.ThuongHieuXe)
                .HasForeignKey(e => e.IDHangXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThuongHieuXe>()
                .HasMany(e => e.VatTus)
                .WithOptional(e => e.ThuongHieuXe)
                .HasForeignKey(e => e.IDHangXe);

            modelBuilder.Entity<TiepNhanXe>()
                .HasMany(e => e.SuaChuas)
                .WithOptional(e => e.TiepNhanXe)
                .HasForeignKey(e => e.IDTiepNhan);

            modelBuilder.Entity<TonKho>()
                .HasMany(e => e.CTTonKhoes)
                .WithRequired(e => e.TonKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ChiTietUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DoanhThus)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IDNguoiDung);

            modelBuilder.Entity<VatTu>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<VatTu>()
                .HasMany(e => e.ChiTietSuaChuas)
                .WithOptional(e => e.VatTu)
                .HasForeignKey(e => e.IDMaVatTu);

            modelBuilder.Entity<VatTu>()
                .HasMany(e => e.CTNhapKhoes)
                .WithRequired(e => e.VatTu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VatTu>()
                .HasMany(e => e.CTTonKhoes)
                .WithRequired(e => e.VatTu)
                .WillCascadeOnDelete(false);
        }
    }
}
