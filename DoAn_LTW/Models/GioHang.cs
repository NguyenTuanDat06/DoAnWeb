using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DoAn_LTW.Models;

namespace DoAn_LTW.Models
{
    public class GioHang
    {
        Model data = new Model();
        public int masach { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        public string tensach { get; set; }
        [Display(Name = "Ảnh Sản Phẩm")]
        public string hinh { get; set; }
        [Display(Name = "Giá Bán")]
        public double giaban { get; set; }
        [Display(Name = "Số Lượng")]
        public int soluong { get; set; }
        [Display(Name = "Thành Tiền")]
        public double thanhtien
        {
            get { return soluong * giaban; }
        }
        public GioHang(int id)
        {
            masach = id;
            ThucAn sach = data.ThucAn.Single(n => n.mathucan == masach);
            tensach = sach.tenthucan;
            hinh = sach.hinh;
            giaban = double.Parse(sach.giaban.ToString());
            soluong = 1;
        }
    }
}