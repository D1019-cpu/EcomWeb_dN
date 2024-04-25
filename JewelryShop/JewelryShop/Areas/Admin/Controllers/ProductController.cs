using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JewelryShop.Models;
using JewelryShop.Models.EF;
using PagedList;

namespace JewelryShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Product
        public ActionResult Index(string SearchText, int? page)
        {
            var pageSize = 5; // items per page
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.UpdatedAt);
            if (!String.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.Slug.Contains(SearchText) || x.Name.Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }


        // GET: /Admin/Product/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: /Admin/Product/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                model.Slug = JewelryShop.Models.Reused.Filter.FilterChar(model.Name);
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Admin/Product/Edit/5/
        public ActionResult Edit(int id)
        {
            var item = db.Products.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // POST: /Admin/Product/Edit/5/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                db.Products.Attach(model);
                model.UpdatedAt = DateTime.Now;
                model.Slug = JewelryShop.Models.Reused.Filter.FilterChar(model.Name);
                db.Entry(model).Property(x => x.Name).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Slug).IsModified = true;
                db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                db.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                db.Entry(model).Property(x => x.IsPublished).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedAt).IsModified = true;
                // image, featured
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: /Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsPublished = !item.IsPublished;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsPublished });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!String.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Products.Find(Convert.ToInt32(item));
                        db.Products.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}