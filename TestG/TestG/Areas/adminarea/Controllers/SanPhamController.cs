using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;
using TestG.Models;
namespace TestG.Areas.adminarea.Controllers
{
    public class SanPhamController : Controller
    {
        DA_QLGarageEntities db = new DA_QLGarageEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}