using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeightTracker.Models;

namespace WeightTracker.Controllers
{
    public class WeightEntriesController : Controller
    {
        private WeightContext db = new WeightContext();

        // index view... this method returns the weight history ordered by date
        public ActionResult Index()
        {
            //var filteredByDate = db.WeightEntries.OrderByDescending(fd => fd.Date).ToList();
            return View(db.WeightEntries.OrderByDescending(fd => fd.Date).ToList());
            //return View(db.WeightEntries.ToList());
        }

        // Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightEntry weightEntry = db.WeightEntries.Find(id);
            if (weightEntry == null)
            {
                return HttpNotFound();
            }
            return View(weightEntry);
        }

        // Create... this is a blank create view waiting for user input
        public ActionResult Create()
        {
            return View();
        }

        // Create... this posts the info for the create view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Weight,Date")] WeightEntry weightEntry)
        {
            if (ModelState.IsValid)
            {
                
                db.WeightEntries.Add(weightEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weightEntry);
        }

        // Edit... this gets the info for the edit view
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightEntry weightEntry = db.WeightEntries.Find(id);
            if (weightEntry == null)
            {
                return HttpNotFound();
            }
            return View(weightEntry);
        }

        // Edit... this posts the updated info for the edit view
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Weight,Date")] WeightEntry weightEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weightEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weightEntry);
        }

        // Delete... this gets the info for the edit view
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightEntry weightEntry = db.WeightEntries.Find(id);
            if (weightEntry == null)
            {
                return HttpNotFound();
            }
            return View(weightEntry);
        }

        // Delete... this posts the info for the delete view
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeightEntry weightEntry = db.WeightEntries.Find(id);
            db.WeightEntries.Remove(weightEntry);
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

        public void DateCheck()
        {

        }

    }
}
