using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;

namespace DoAn_LTW.Controllers
{
    public class TimKiemController : Controller
    {
        Model db = new Model();
        // GET: TimKiem
        public ActionResult KQTimKiem(string TuKhoa)
        {
            var lstsp = db.ThucAn.Where(n => n.tenthucan.Contains(TuKhoa));
            return View(lstsp.OrderBy(n=>n.tenthucan));
        }

        public ActionResult KQTimKiemKH(string TuKhoa)
        {
            var lstsp = db.ThucAn.Where(n => n.tenthucan.Contains(TuKhoa));
            return View(lstsp.OrderBy(n => n.tenthucan));
        }

        public ActionResult KQTimKiemTK(string TuKhoa)
        {
            var lstsp = db.KhachHang.Where(n => n.email.Contains(TuKhoa));
            return View(lstsp.OrderBy(n => n.email));
        }
    }
}