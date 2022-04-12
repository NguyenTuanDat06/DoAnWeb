using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;

namespace DoAn_LTW.Controllers
{
    public class HomeController : Controller
    {
        Model db = new Model();
        public ActionResult Index()
        {
            //Tạo viewbag
            List<ThucAn> listheo = db.ThucAn.Where(n => n.maloai == 1).ToList();
            List<ThucAn> listga = db.ThucAn.Where(n => n.maloai == 2).ToList();
            List<ThucAn> listvit = db.ThucAn.Where(n => n.maloai == 3).ToList();
            List<ThucAn> listde = db.ThucAn.Where(n => n.maloai == 4).ToList();


            ViewBag.listheo = listheo;
            ViewBag.listga = listga;
            ViewBag.listvit = listvit;
            ViewBag.listde = listde;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult SanPham()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}