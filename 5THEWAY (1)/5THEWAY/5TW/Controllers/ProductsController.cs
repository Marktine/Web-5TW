using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _5TW.Models;

namespace _5TW.Controllers
{
    public class ProductsController : Controller
    {
        private webBanHangEntities db = new webBanHangEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ClothesType).Include(p => p.Collection);
            return View(products.ToList());
        }


        //GET all of Top products's type
        public List<string> AllShirtsType()
        {
            List<string> ct;
            ct = db.ClothesTypes.Where(p => db.ClothesTypes.All(l => p.CloID == 1 || p.CloID == 2 || p.CloID == 3 || p.CloID == 4)).Select(c => c.CloName).ToList();
            return ct;
        }

        //GET all of Bottom product's type
        public List<string> AllBottomType()
        {
            List<string> cb;
            cb = db.ClothesTypes.Where(p => db.ClothesTypes.All(l => p.CloID == 5 || p.CloID == 6 || p.CloID == 7 || p.CloID == 8)).Select(c => c.CloName).ToList();
            return cb;
        }

        //GET a bottom product's type by idtype
        public string BottomType(int? idtype)
        {
            string cb = string.Empty;
            if (!(idtype == 0 || idtype == null))
            {
                cb = db.ClothesTypes.FirstOrDefault(c => c.CloID == idtype).CloName;
            }
            return cb;
        }

        //GET get a shirt's type by idtype
        public string ShirtsType(int? idtype)
        {
            string ct = string.Empty;
            if(!(idtype == 0 || idtype == null))
            {
                ct = db.ClothesTypes.FirstOrDefault(c => c.CloID == idtype).CloName;
            }
            return ct;
        }

        //GET Top products by idtype
        public ActionResult Top(int? idtype)
        {
            var svm = new TopViewModel();
            svm.AllShirtsType = new List<string>();
            svm.AllShirtsType = AllShirtsType();
            if (idtype == 0 || idtype == null)
            {
                svm.lstShirts = db.Products.Where(p => db.Products.All(l => p.CloType == 1 || p.CloType == 2 || p.CloType == 3 || p.CloType == 4)).ToList();
                svm.Title = "Top";
                return View(svm);
            }
            else
            {
                svm.lstShirts = db.Products.Where(p => db.Products.Any(l => p.CloType == idtype)).ToList();
                svm.Title = ShirtsType(idtype);
                return View(svm);
            }
        }

        //GET Bottom products by idtype
        public ActionResult Bottom(int? idtype)
        {
            var svm = new BottomViewModel();
            svm.AllBottomTypes = new List<string>();
            svm.AllBottomTypes = AllBottomType();
            if (idtype == 0 || idtype == null)
            {
                svm.lsBottomProducts = db.Products.Where(p => db.Products.All(l => p.CloType == 5 || p.CloType == 6 || p.CloType == 7 || p.CloType == 8)).ToList();
            }
            else
            {
                svm.lsBottomProducts = db.Products.Where(p => db.Products.Any(l => p.CloType == idtype)).ToList();
            }
            return View(svm);
        }

        //GET Accessories Products by id
        public ActionResult Accessories(int? idtype)
        {
            var svm = new AccessoriesViewModel();
            svm.AllAccessoriesTypes = new List<string>();
            svm.AllAccessoriesTypes = db.Products.Where(p => p.CloType == 9).Select(p => p.ClothesType.CloName).ToList();
            svm.lsAccessories = db.Products.Where(p => p.CloType == 9).ToList();
            return View(svm);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.First(p => p.ProID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CloType = new SelectList(db.ClothesTypes, "CloID", "CloName");
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProID,Name,Picture,CloType,CollectionID,Size,Price,Quantity,EntryDate,Description,Status")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CloType = new SelectList(db.ClothesTypes, "CloID", "CloName", product.CloType);
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName", product.CollectionID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CloType = new SelectList(db.ClothesTypes, "CloID", "CloName", product.CloType);
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName", product.CollectionID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProID,Name,Picture,CloType,CollectionID,Size,Price,Quantity,EntryDate,Description,Status")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CloType = new SelectList(db.ClothesTypes, "CloID", "CloName", product.CloType);
            ViewBag.CollectionID = new SelectList(db.Collections, "CollectionID", "CollectionName", product.CollectionID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
