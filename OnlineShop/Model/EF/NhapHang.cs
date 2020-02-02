namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapHang")]
    public partial class NhapHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhapHang()
        {
            ChitietNhapHangs = new HashSet<ChitietNhapHang>();
        }

        [Key]
        public int MaNH { get; set; }

        public decimal? TongTien { get; set; }

        public DateTime NgayNhap { get; set; }

        public int? NguoiNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChitietNhapHang> ChitietNhapHangs { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
