using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeProject.Models;

namespace CafeProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Category()
        {    using (Dbmodel dbmodel=new Dbmodel())
            {
                return View(dbmodel.Category_table.ToList());
            }
                
        }

       
        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category_table collection)
        {
            try
            {
                using(Dbmodel dbmodel=new Dbmodel())
                {
                    dbmodel.Category_table.Add(collection);
                    dbmodel.SaveChanges();
                }
                return RedirectToAction("Category");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.Category_table.Where(x => x.CategoryID == id).FirstOrDefault());
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category_table collection)
        {
            try
            {

                using (Dbmodel dbmodel = new Dbmodel())
                {
                    dbmodel.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }
                    return RedirectToAction("Category");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            using (Dbmodel dbmodel = new Dbmodel())
            {
                return View(dbmodel.Category_table.Where(x => x.CategoryID == id).FirstOrDefault());
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category_table collection)
        {
            try
            {
                using (Dbmodel dbmodel = new Dbmodel())
                {
                    Category_table category = dbmodel.Category_table.Where(x => x.CategoryID == id).FirstOrDefault();
                    dbmodel.Category_table.Remove(category);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Category");
            }
            catch
            {
                return View();
            }
        }
    }
}
