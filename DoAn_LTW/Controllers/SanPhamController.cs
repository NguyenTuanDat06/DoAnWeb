using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;

namespace DoAn_LTW.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        Model dbThucAn = new Model();
        public ActionResult Index()
        {
            var listThucAn = dbThucAn.ThucAn.ToList();
            return View(listThucAn);
        }
        public ActionResult SanPhamList()
        {
            return PartialView();
        }
        public ActionResult Detail(int id)
        {
            var D_thucAn = dbThucAn.ThucAn.Where(m => m.mathucan == id).First();
            return View(D_thucAn);
        }
    }
}