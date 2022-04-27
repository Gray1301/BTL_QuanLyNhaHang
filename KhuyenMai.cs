namespace BTL_Nhom11
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [Key]
        [StringLength(10)]
        public string ma_km { get; set; }

        [StringLength(30)]
        public string ten_km { get; set; }

        public int? yeu_cau { get; set; }

        public int? tien_giam { get; set; }
    }
}
