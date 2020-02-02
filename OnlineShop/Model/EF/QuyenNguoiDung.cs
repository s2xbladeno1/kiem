namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuyenNguoiDung")]
    public partial class QuyenNguoiDung
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string GroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string QuyenID { get; set; }

        public bool? TinhTrang { get; set; }

        public virtual NhomNguoiDung NhomNguoiDung { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
