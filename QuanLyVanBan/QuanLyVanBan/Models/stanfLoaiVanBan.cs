namespace QuanLyVanBan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stanfLoaiVanBan")]
    public partial class stanfLoaiVanBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stanfLoaiVanBan()
        {
            stanfVanBans = new HashSet<stanfVanBan>();
        }

        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(500)]
        public string TenLoaiVanVan { get; set; }

        public string MoTa { get; set; }

        public int? NumberOder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stanfVanBan> stanfVanBans { get; set; }
    }
}
