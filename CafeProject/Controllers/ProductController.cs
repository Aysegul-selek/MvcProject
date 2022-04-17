using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeProject.Models;
using Newtonsoft.Json;

namespace CafeProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product()
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.product_table.ToList());
            }

        }

        public ActionResult Admin()
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                
                return View(dbmodel.product_table.ToList());
            }
        }
       
        public ActionResult Currency()
        {
            
                List<Currency> CurList = null;
                WebClient client = new WebClient();
                var json = client.DownloadString("http://www.tcmb.gov.tr/kurlar");
                CurList = JsonConvert.DeserializeObject<List<Currency>>(json);
                if (CurList == null)
                    return null;

                return View(CurList.Take(3).ToList());
            
           
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    dbmodel.product_table.Add(collection);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.product_table.Where(x => x.ProductID == id).FirstOrDefault());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, product_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    dbmodel.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Product");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.product_table.Where(x => x.ProductID == id).FirstOrDefault());
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, product_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    product_table product = dbmodel.product_table.Where(x => x.ProductID == id).FirstOrDefault();
                    dbmodel.product_table.Remove(product);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Product");
            }
            catch
            {
                return View();
            }
        }
    }
}
