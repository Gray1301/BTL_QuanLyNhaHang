namespace BTL_Nhom11
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_hd { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ma_sp { get; set; }

        public int? SoLuong { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual Menu_SanPham Menu_SanPham { get; set; }
    }
}
