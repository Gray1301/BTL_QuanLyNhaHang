namespace BTL_Nhom11
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int ma_nv { get; set; }

        [StringLength(60)]
        public string ten_nv { get; set; }

        [StringLength(30)]
        public string username { get; set; }

        [StringLength(75)]
        public string password { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_sinh { get; set; }

        [StringLength(30)]
        public string chuc_vu { get; set; }

        public int? Luong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
