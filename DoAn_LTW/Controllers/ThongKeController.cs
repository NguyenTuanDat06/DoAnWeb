using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;

namespace DoAn_LTW.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        Model db = new Model();
        public ActionResult ThongKeDonHang()
        {
            var lstDonHang = db.DonHang.ToList();
            return View(lstDonHang);
        }

        public ActionResult ChiTietDonHang(int id)
        {
            ViewBag.TongTien = TongTienDonHang(id);
            var D_thucAn = db.ChiTietDonHang.Where(m => m.madon == id).ToList();
            return View(D_thucAn);
        }
        private double TongTienDonHang(int id)
        {
            var D_thucAn = db.DonHang.Where(m => m.madon == id);
            double tt = 0;    
            foreach(var item in D_thucAn)
            {
                tt += double.Parse(item.ChiTietDonHang.Sum(n=>n.soluong*n.gia).Value.ToString());
            }    
            return tt;
        }


    }
}