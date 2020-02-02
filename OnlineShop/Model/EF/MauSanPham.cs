namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MauSanPham")]
    public partial class MauSanPham
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        [Display(Name = "Sản Phẩm")]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        [Display(Name = "Màu")]
        public string MaMau { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        [Display(Name = "Tình Trạng")]
        public string MaTT { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        [Display(Name = "Dung Lượng")]
        public string MaDL { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên đầy đủ")]
        public string TenDayDu { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        [StringLength(50)]
        [Display(Name = "Ảnh")]
        public string Anh { get; set; }

        [Display(Name = "Giá")]
        public decimal Gia { get; set; }

        [Display(Name = "Số Lượng Còn")]
        public int SoLuongCon { get; set; }

        public virtual DungLuong DungLuong { get; set; }

        public virtual MauSac MauSac { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual TinhTrangMay TinhTrangMay { get; set; }
    }
}
