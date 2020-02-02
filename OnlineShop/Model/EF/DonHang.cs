namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name = "Mã Đơn Hàng")]
        public int MaDH { get; set; }

        [Display(Name = "Mã Khách Hàng")]
        public int? MaKH { get; set; }

        [Display(Name = "Ngày Đặt Hàng")]
        public DateTime NgayBan { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Người Đặt")]
        public string HoTen { get; set; }

        [StringLength(10)]
        [Display(Name = "Số Điện Thoại")]
        public string SDT { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Địa Chỉ Nhận")]
        public string DiaChiNhan { get; set; }

        [Display(Name = "Tổng Tiền")]
        public decimal? TongTien { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng Thái")]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
