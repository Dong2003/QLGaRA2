using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestG.Areas.adminarea.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: adminarea/Home
        public ActionResult IndexAdmin()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhap", "User");
            }

            return View();
        }
        public ActionResult NavPartialAdmin()
        {
            return PartialView();
        }
        public ActionResult MenuPartialAdmin()
        {
            return PartialView();
        }
        public ActionResult FooterPartialAdmin()
        {
            return PartialView();
        }

        public ActionResult QuenMatKhau()
        {
            return View();
        }
        public ActionResult TaoTaiKhoan()
        {
            return View();
        }
    }
}