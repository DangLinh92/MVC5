namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stanfDonVi")]
    public partial class stanfDonVi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stanfDonVi()
        {
            stanfVanBans = new HashSet<stanfVanBan>();
        }

        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDonVi { get; set; }

        [StringLength(250)]
        public string TenDonVi { get; set; }

        [StringLength(50)]
        public string DonViCapTrenId { get; set; }

        [StringLength(12)]
        public string DienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stanfVanBan> stanfVanBans { get; set; }
    }
}
