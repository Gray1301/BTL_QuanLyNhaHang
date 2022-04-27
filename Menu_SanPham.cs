namespace BTL_Nhom11
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Menu_SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu_SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        public int ma_sp { get; set; }

        [StringLength(60)]
        public string ten_sp { get; set; }

        [StringLength(200)]
        public string mo_ta { get; set; }

        public int? don_gia { get; set; }

        [StringLength(20)]
        public string loai { get; set; }

        [Column(TypeName = "image")]
        public byte[] anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
