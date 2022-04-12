namespace DoAn_LTW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucAn")]
    public partial class ThucAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucAn()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public int mathucan { get; set; }

        public int? maloai { get; set; }

        [Required]
        [StringLength(100)]
        public string tenthucan { get; set; }

        [StringLength(500)]
        public string mota { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        public decimal? giaban { get; set; }

        public int? soluongton { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual TheLoai TheLoai { get; set; }

        public List<TheLoai> lstTheLoai = new List<TheLoai>();
    }
}
