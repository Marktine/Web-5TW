using _5TW.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5TW.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index(string searchKey = "")
        {
            SearchViewModel svm = new SearchViewModel();
            svm.searchKey = searchKey;
            svm.lsProduct = new List<Product>();
            using (var db = new webBanHangEntities())
            {
                svm.lsProduct = db.Database.SqlQuery<Product>("exec USP_Search '" + searchKey + "'").ToList();
                return View(svm);
            }
        }
    }
}