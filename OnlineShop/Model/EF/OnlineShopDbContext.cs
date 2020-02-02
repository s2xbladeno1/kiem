namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext()
            : base("name=OnlineShopDbContext")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChitietNhapHang> ChitietNhapHangs { get; set; }
        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<DungLuong> DungLuongs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<MauSanPham> MauSanPhams { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhapHang> NhapHangs { get; set; }
        public virtual DbSet<NhomNguoiDung> NhomNguoiDungs { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<QuyenNguoiDung> QuyenNguoiDungs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TinhTrangMay> TinhTrangMays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaMau)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<BinhLuan>()
                .Property(e => e.MaDL)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaMau)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaDL)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChitietNhapHang>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<ChitietNhapHang>()
                .Property(e => e.MaMau)
                .IsUnicode(false);

            modelBuilder.Entity<ChitietNhapHang>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<ChitietNhapHang>()
                .Property(e => e.MaDL)
                .IsUnicode(false);

            modelBuilder.Entity<ChitietNhapHang>()
                .Property(e => e.GiaNhap)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChitietNhapHang>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DanhMucSanPham>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucSanPham>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucSanPham>()
                .Property(e => e.DaCap)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucSanPham>()
                .Property(e => e.MaLSP)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.DanhMucSanPham)
                .HasForeignKey(e => e.DMSPID);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DungLuong>()
                .Property(e => e.MaDL)
                .IsUnicode(false);

            modelBuilder.Entity<DungLuong>()
                .Property(e => e.BoNho)
                .IsUnicode(false);

            modelBuilder.Entity<DungLuong>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DungLuong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DungLuong>()
                .HasMany(e => e.ChitietNhapHangs)
                .WithRequired(e => e.DungLuong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DungLuong>()
                .HasMany(e => e.MauSanPhams)
                .WithRequired(e => e.DungLuong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSanPham>()
                .Property(e => e.MaLSP)
                .IsUnicode(false);

            modelBuilder.Entity<MauSac>()
                .Property(e => e.MaMau)
                .IsUnicode(false);

            modelBuilder.Entity<MauSac>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.MauSac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MauSac>()
                .HasMany(e => e.ChitietNhapHangs)
                .WithRequired(e => e.MauSac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MauSac>()
                .HasMany(e => e.MauSanPhams)
                .WithRequired(e => e.MauSac)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MauSanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<MauSanPham>()
                .Property(e => e.MaMau)
                .IsUnicode(false);

            modelBuilder.Entity<MauSanPham>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<MauSanPham>()
                .Property(e => e.MaDL)
                .IsUnicode(false);

            modelBuilder.Entity<MauSanPham>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<MauSanPham>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<MauSanPham>()
                .Property(e => e.Gia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.NhapHangs)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.NguoiNhap);

            modelBuilder.Entity<NhapHang>()
                .Property(e => e.TongTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NhapHang>()
                .HasMany(e => e.ChitietNhapHangs)
                .WithRequired(e => e.NhapHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<NhomNguoiDung>()
                .HasMany(e => e.NguoiDungs)
                .WithOptional(e => e.NhomNguoiDung)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<NhomNguoiDung>()
                .HasMany(e => e.QuyenNguoiDungs)
                .WithRequired(e => e.NhomNguoiDung)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.QuyenNguoiDungs)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyenNguoiDung>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<QuyenNguoiDung>()
                .Property(e => e.QuyenID)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.DMSPID)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Ram)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.CamChinh)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.CamPhu)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.CPU)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.DoPhanGiai)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.DLPin)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.HeDH)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.KTManHinh)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChitietNhapHangs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.MauSanPhams)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinhTrangMay>()
                .Property(e => e.MaTT)
                .IsUnicode(false);

            modelBuilder.Entity<TinhTrangMay>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.TinhTrangMay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinhTrangMay>()
                .HasMany(e => e.ChitietNhapHangs)
                .WithRequired(e => e.TinhTrangMay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinhTrangMay>()
                .HasMany(e => e.MauSanPhams)
                .WithRequired(e => e.TinhTrangMay)
                .WillCascadeOnDelete(false);
        }
    }
}
