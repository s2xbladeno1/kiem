namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucSanPham")]
    public partial class DanhMucSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [StringLength(20)]
        public string ID { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [StringLength(100)]
        public string Url { get; set; }

        [StringLength(20)]
        [Display(Name = "Danh Mục Cha")]
        public string DaCap { get; set; }

        [StringLength(10)]
        [Display(Name = "Loại Sản Phẩm")]
        public string MaLSP { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
