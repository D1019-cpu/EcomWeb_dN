using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JewelryShop.Models.EF;
using PagedList;
using System.Web.UI;
using JewelryShop.Models;

namespace JewelryShop.Areas.Admin.Controllers
{
    public class PromotionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Promotion
        public ActionResult Index(string SearchText, int? page)
        {
            var pageSize = 5; // items per page
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Promotion> items = db.Promotions.OrderByDescending(x => x.UpdatedAt);
            if (!String.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x => x.PromotionName.Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        // GET: /Admin/Promotion/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: /Admin/Promotion/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Promotion model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;
                db.Promotions.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Admin/Promotion/Edit/5/
        public ActionResult Edit(int id)
        {
            var item = db.Promotions.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // POST: /Admin/Promotion/Edit/5/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Promotion model)
        {
            if (ModelState.IsValid)
            {
                db.Promotions.Attach(model);
                model.UpdatedAt = DateTime.Now;
                db.Entry(model).Property(x => x.PromotionName).IsModified = true;
                db.Entry(model).Property(x => x.DiscountPercentage).IsModified = true;
                db.Entry(model).Property(x => x.IsActive).IsModified = true;
                db.Entry(model).Property(x => x.UpdatedAt).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: /Admin/Promotion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Promotions.Find(id);
            if (item != null)
            {
                db.Promotions.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Promotions.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
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
                        var obj = db.Promotions.Find(Convert.ToInt32(item));
                        db.Promotions.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }


    }
}