using DiemCong_LeDinhPhuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiemCong_LeDinhPhuc.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public ActionResult Index()
        {
            var all_sv = from sv in data.SinhViens select sv;
            return View(all_sv);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_masv = collection["MaSV"];
            var E_hoten = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(E_masv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = E_masv.ToString();
                s.HoTen = E_hoten.ToString();
                s.GioiTinh = E_gioitinh.ToString();
                s.NgaySinh = E_ngaysinh;
                s.Hinh = E_hinh.ToString();
                s.MaNganh = E_manganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}