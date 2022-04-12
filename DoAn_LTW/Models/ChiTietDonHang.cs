namespace DoAn_LTW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int madon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mathucan { get; set; }

        public int? soluong { get; set; }

        public decimal? gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual ThucAn ThucAn { get; set; }
        public double thanhtien
        {
            get { return (double)(soluong * gia); }
        }
    }
}
