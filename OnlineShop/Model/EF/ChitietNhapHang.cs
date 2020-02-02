namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChitietNhapHang")]
    public partial class ChitietNhapHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã Nhập Hàng")]
        public int MaNH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        [Display(Name = "Sản phẩm")]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        [Display(Name = "Màu")]
        public string MaMau { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        [Display(Name = "Tình Trạng")]
        public string MaTT { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        [Display(Name = "Dung Lượng")]
        public string MaDL { get; set; }

        [Display(Name = "Số Lượng Nhập")]
        public int? SoLuongNhap { get; set; }

        [Display(Name = "Giá Nhập")]
        public decimal? GiaNhap { get; set; }

        [Display(Name = "Thành Tiền")]
        public decimal? ThanhTien { get; set; }

        public virtual MauSac MauSac { get; set; }

        public virtual DungLuong DungLuong { get; set; }

        public virtual NhapHang NhapHang { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual TinhTrangMay TinhTrangMay { get; set; }
    }
}
