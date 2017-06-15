using _5TW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5TW.Controllers
{
    public class HomeController : Controller
    {
        private webBanHangEntities db = new webBanHangEntities();

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Shirt(int? typeid)
        //{
        //    var products = db.Products.Where(p => db.Products.Any(l => p.CloType == typeid)).ToList();
        //    return View(products);
        //}

        //public ActionResult Shirts(int? idtype)
        //{

        //}

        public ActionResult Pants()
        {
            ViewBag.Title = "5TW-Pants";
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Collections()
        {
            ViewBag.Title = "5TW-Collections";
            return View();
        }

        public ActionResult Collaboration()
        {
            ViewBag.Title = "5TW-Collaboration";
            return View();
        }
        public ActionResult OOTD()
        {
            ViewBag.Title = "5TW-OOTD";
            return View();
        }
        public ActionResult  Accessories()
        {
            ViewBag.Title = "5TW-Accessories";
            return View();
        }
        
        public ActionResult  Information()
        {
            ViewBag.Title = "Information";
            return View();
        }
    }
}