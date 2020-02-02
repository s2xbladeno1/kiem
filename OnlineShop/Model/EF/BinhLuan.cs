namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        public int MaBL { get; set; }

        public int NguoiDungID { get; set; }

        [StringLength(10)]
        public string MaSP { get; set; }

        [StringLength(10)]
        public string MaMau { get; set; }

        [StringLength(2)]
        public string MaTT { get; set; }

        [StringLength(10)]
        public string MaDL { get; set; }

        [StringLength(500)]
        public string NoiDung { get; set; }

        public double? DanhGia { get; set; }
        public int? ReplyID { get; set; }

        public virtual DungLuong DungLuong { get; set; }

        public virtual MauSac MauSac { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual TinhTrangMay TinhTrangMay { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
