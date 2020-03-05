namespace BookStoreAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string TenSach { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        [StringLength(100)]
        public string AnhDaiDien { get; set; }

        [StringLength(30)]
        public string TacGia { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayXuatBan { get; set; }

        [StringLength(10)]
        public string ChuDeId { get; set; }

        public double? GiaBan { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public virtual ChuDe ChuDe { get; set; }
    }
}
