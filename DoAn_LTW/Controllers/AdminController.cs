using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;
using PagedList;

namespace DoAn_LTW.Controllers
{
    public class AdminController : Controller
    {
        Model dbThucAn = new Model();
        // GET: Admin
        public ActionResult Index(int ? page)
        {
            var listThucAn = dbThucAn.ThucAn.ToList();
            if (page == null) page = 1;
            int pageSize = 6;
            int pageNum = page ?? 1;
            return View(listThucAn.ToPagedList(pageNum, pageSize));
        }
        public ActionResult Detail(int id)
        {
            var D_thucAn = dbThucAn.ThucAn.Where(m => m.mathucan == id).First();
            return View(D_thucAn);
        }
        public ActionResult Edit(int id)
        {
            var E_Sach = dbThucAn.ThucAn.First(m => m.mathucan == id);
            return View(E_Sach);

        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_rubik = dbThucAn.ThucAn.First(m => m.mathucan == id);
            var E_maloai = Convert.ToInt32(collection["maloai"]);
            var E_ten = collection["tenthucan"];
            var E_mota = collection["mota"];
            var E_gia = Convert.ToDecimal(collection["giaban"]);
            var E_hinh = collection["hinh"];
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_rubik.mathucan = id;
            if (string.IsNullOrEmpty(E_ten))
            {
                ViewData["Error"] = "Don't empty";
            }
            else
            {
                E_rubik.tenthucan = E_ten.ToString();
                E_rubik.mota = E_mota.ToString();
                E_rubik.giaban = E_gia;
                E_rubik.hinh = E_hinh.ToString();
                E_rubik.soluongton = E_soluongton;
                UpdateModel(E_rubik);
                dbThucAn.SaveChanges();

                return RedirectToAction("Index", "Admin");
            }
            return this.Edit(id);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/img/" +
            file.FileName));
            return "/Content/img/" + file.FileName;
        }

        public ActionResult Delete(int id)
        {
            var E_Sach = dbThucAn.ThucAn.First(m => m.mathucan == id);
            return View(E_Sach);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_Sach = dbThucAn.ThucAn.Where(m => m.mathucan == id).First();
            if (D_Sach.soluongton == 0)
            {    
                dbThucAn.ThucAn.Remove(D_Sach);
            dbThucAn.SaveChanges();
            return RedirectToAction("Index", "Admin");
            } 
            else
            {
                return View("ThongBaoXoa");
            }    
            return View();
        }

        public ActionResult Create()
        {
            ThucAn objCourse = new ThucAn();
            objCourse.lstTheLoai = dbThucAn.TheLoai.ToList();
            return View(objCourse);
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, ThucAn s)
        {   
            var E_maloai = Convert.ToInt32(collection["maloai"]);
            var E_tensach = collection["tenthucan"];
            var E_mota = collection["mota"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                if(E_soluongton < 0)
                {
                    ViewBag.ThongBao = "Số Lượng không Hợp Lệ ";
                }
                else
                { 
                s.maloai = E_maloai;
                s.tenthucan = E_tensach.ToString();
                s.mota = E_mota.ToString();
                s.hinh = E_hinh.ToString();
                s.giaban = E_giaban;
                s.soluongton = E_soluongton;
                dbThucAn.ThucAn.Add(s);
                dbThucAn.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
        }
            return this.Create();
        }
        public ActionResult DangXuat()
        {
            Session["email"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DSTK()
        {
            var listThucAn = dbThucAn.KhachHang.ToList();
            return View(listThucAn);
        }
        public ActionResult EditTK(int id)
        {
            var listThucAn = dbThucAn.KhachHang.ToList();
            List<KhachHang> listGioHang = listThucAn;
            KhachHang sanpham = listGioHang.SingleOrDefault(n => n.makh == id);
            if (sanpham != null)
            {
                sanpham.matkhau = 123456.ToString();
                dbThucAn.SaveChanges();
                var mail = new email();
                mail.SendEMailReset(sanpham.email, sanpham.hoten);
                return View("View");
            }
            return RedirectToAction("DSTK");
        }

    }
}