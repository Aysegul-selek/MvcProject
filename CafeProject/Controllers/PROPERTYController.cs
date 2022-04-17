using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeProject.Models;

namespace CafeProject.Controllers
{
    public class PROPERTYController : Controller
    {
        // GET: PROPERTY
        public ActionResult PROPERTY()
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.property_table.ToList());
            }
        }

       

        // GET: PROPERTY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PROPERTY/Create
        [HttpPost]
        public ActionResult Create(property_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    dbmodel.property_table.Add(collection);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("PROPERTY");
            }
            catch
            {
                return View();
            }
        }

        // GET: PROPERTY/Edit/5
        public ActionResult Edit(int id)
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.property_table.Where(x => x.ProperyID == id).FirstOrDefault());
            }
        }

        // POST: PROPERTY/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, property_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    dbmodel.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("PROPERTY ");
            }
            catch
            {
                return View();
            }
        }

        // GET: PROPERTY/Delete/5
        public ActionResult Delete(int id)
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.property_table.Where(x => x.ProperyID == id).FirstOrDefault());
            }
        }

        // POST: PROPERTY/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    property_table product = dbmodel.property_table.Where(x => x.ProperyID == id).FirstOrDefault();
                    dbmodel.property_table.Remove(product);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("PROPERTY ");
            }
            catch
            {
                return View();
            }
        }
    }
}
