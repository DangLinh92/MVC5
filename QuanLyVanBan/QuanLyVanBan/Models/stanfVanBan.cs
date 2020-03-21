using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace QuanLyVanBan.Models
{
    [Table("stanfVanBan")]
    public partial class stanfVanBan
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaVanBan { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }

        public string MoTa { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayVanBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDuyet { get; set; }

        [StringLength(50)]
        public string TenFile { get; set; }

        [StringLength(500)]
        public string DuongDan { get; set; }

        [StringLength(10)]
        public string DinhDang { get; set; }

        public int? SoTrang { get; set; }

        [StringLength(50)]
        public string LoaiVanBanId { get; set; }

        [StringLength(50)]
        public string DonViId { get; set; }

        public virtual stanfDonVi stanfDonVi { get; set; }

        public virtual stanfLoaiVanBan stanfLoaiVanBan { get; set; }
    }
}
