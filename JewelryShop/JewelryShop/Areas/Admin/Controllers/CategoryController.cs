using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JewelryShop.Models;
using JewelryShop.Models.EF;


namespace JewelryShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = db.Categories.OrderByDescending(x => x.UpdatedAt).ToPagedList(pageIndex, pageSize);
            //items = items.ToPagedList(pageIndex, pageSize);
            
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        // GET: /Admin/Category/Add
        public ActionResult Add ()
        {
            return View();
        }

        // POST: /Admin/Category/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add (Category model)
        {
            if (ModelState.IsValid)
            {   
                model.CreatedAt= DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                model.Slug = JewelryShop.Models.Reused.Filter.FilterChar(model.Name);
                db.Categories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(model);
        }

        // GET: /Admin/Category/Edit/5/
        public ActionResult Edit(int id)
        {
            var item = db.Categories.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }    
            return View(item);
        }

        // POST: /Admin/Category/Edit/5/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(model);
                model.UpdatedAt = DateTime.Now;
                model.Slug = JewelryShop.Models.Reused.Filter.FilterChar(model.Name);
                db.Entry(model).Property(x => x.Name).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Slug).IsModified = true;
                db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                db.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                db.Entry(model).Property(x => x.IsActive).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedAt).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model) ;
        }

        // POST: /Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete (int id)
        {
            var item = db.Categories.Find(id);
            if (item != null)
            {
                db.Categories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive (int id)
        {
            var item = db.Categories.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }
        

    }
}