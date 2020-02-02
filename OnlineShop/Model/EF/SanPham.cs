namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuans = new HashSet<BinhLuan>();
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ChitietNhapHangs = new HashSet<ChitietNhapHang>();
            MauSanPhams = new HashSet<MauSanPham>();
        }
        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        [StringLength(100)]
        public string TenSP { get; set; }

        [StringLength(100)]
        public string Url { get; set; }
        [Display(Name = "Loại Sản Phẩm")]
        [StringLength(10)]
        public string MaLSP { get; set; }

        [Display(Name = "Danh mục")]
        [StringLength(20)]
        public string DMSPID { get; set; }
        [Display(Name = "Tổng Số Lượng")]
        public int TongSL { get; set; }
        [Display(Name = "Mô Tả")]
        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string Ram { get; set; }

        [Display(Name = "Camera Chính")]
        [StringLength(50)]
        public string CamChinh { get; set; }

        [Display(Name = "Camera Phụ")]
        [StringLength(50)]
        public string CamPhu { get; set; }
        
        [StringLength(50)]
        public string CPU { get; set; }

        [Display(Name = "Độ Phân Giải")]
        [StringLength(50)]
        public string DoPhanGiai { get; set; }

        [Display(Name = "Dung Lượng Pin")]
        [StringLength(50)]
        public string DLPin { get; set; }

        [Display(Name = "Hệ Điều Hành")]
        [StringLength(50)]
        public string HeDH { get; set; }

        [Display(Name = "Kích Thước Màn Hình")]
        [StringLength(50)]
        public string KTManHinh { get; set; }

        [Display(Name = "Chi Tiết")]
        [Column(TypeName = "ntext")]
        public string ChiTiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietNhapHang> ChitietNhapHangs { get; set; }

        public virtual DanhMucSanPham DanhMucSanPham { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauSanPham> MauSanPhams { get; set; }
    }
}
