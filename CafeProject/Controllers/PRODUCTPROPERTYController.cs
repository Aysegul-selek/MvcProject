using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeProject.Models;

namespace CafeProject.Controllers
{
    public class PRODUCTPROPERTYController : Controller
    {
        // GET: PRODUCTPROPERTY
        public ActionResult PRODUCTPROPERTY()
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.productproperty_table.ToList());
            }
        }

       

        // GET: PRODUCTPROPERTY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRODUCTPROPERTY/Create
        [HttpPost]
        public ActionResult Create(productproperty_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    dbmodel.productproperty_table.Add(collection);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("PRODUCTPROPERTY");
            }
            catch
            {
                return View();
            }
        }

        // GET: PRODUCTPROPERTY/Edit/5
        public ActionResult Edit(int? id)
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.productproperty_table.Where(x => x.ProductpropertyID == id).FirstOrDefault());
            }
        }

        // POST: PRODUCTPROPERTY/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, productproperty_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    dbmodel.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("PRODUCTPROPERTY");
            }
            catch
            {
                return View();
            }
        }

        // GET: PRODUCTPROPERTY/Delete/5
        public ActionResult Delete(int? id)
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.productproperty_table.Where(x => x.ProductpropertyID == id).FirstOrDefault());
            }
        }

        // POST: PRODUCTPROPERTY/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, productproperty_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    productproperty_table product = dbmodel.productproperty_table.Where(x => x.ProductpropertyID == id).FirstOrDefault();
                    dbmodel.productproperty_table.Remove(product);
                    dbmodel.SaveChanges();
                }
                return RedirectToAction("PRODUCTPROPERTY");
            }
            catch
            {
                return View();
            }
        }
    }
}
