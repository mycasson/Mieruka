using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mieruka.Models;

namespace Mieruka.Controllers
{
    public class MierukaViewsController : Controller
    {
        private MierukaModel db = new MierukaModel();

        // GET: MierukaViews
        public ActionResult Index(DateTime? date )
        {
            date = date ?? DateTime.Now;
            ViewBag.Date = date;
            DateTime d = date.Value;
            return View(db.MierukaView.Where(m => m.Date.Year == d.Year && m.Date.Month == d.Month && m.Date.Day == d.Day).ToList());
        }

        // GET: MierukaViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MierukaView mierukaView = db.MierukaView.Find(id);
            if (mierukaView == null)
            {
                return HttpNotFound();
            }
            return View(mierukaView);
        }

        // GET: MierukaViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MierukaViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MachineNumber,Plan,Date,ActualCount,Unit")] MierukaView mierukaView)
        {
            if (ModelState.IsValid)
            {
                db.MierukaView.Add(mierukaView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mierukaView);
        }

        // GET: MierukaViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MierukaView mierukaView = db.MierukaView.Find(id);
            if (mierukaView == null)
            {
                return HttpNotFound();
            }
            return View(mierukaView);
        }

        // POST: MierukaViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MachineNumber,Plan,Date,ActualCount,Unit")] MierukaView mierukaView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mierukaView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mierukaView);
        }

        // GET: MierukaViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MierukaView mierukaView = db.MierukaView.Find(id);
            if (mierukaView == null)
            {
                return HttpNotFound();
            }
            return View(mierukaView);
        }

        // POST: MierukaViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MierukaView mierukaView = db.MierukaView.Find(id);
            db.MierukaView.Remove(mierukaView);
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
