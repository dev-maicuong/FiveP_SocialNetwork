using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FivePSocialNetwork.Models;

namespace FivePSocialNetwork.Controllers.ControllerFramword
{
    public class ProvincialsController : Controller
    {
        private FivePSocialNetWorkEntities db = new FivePSocialNetWorkEntities();

        // GET: Provincials
        public ActionResult Index()
        {
            return View(db.Provincials.ToList());
        }

        // GET: Provincials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincial provincial = db.Provincials.Find(id);
            if (provincial == null)
            {
                return HttpNotFound();
            }
            return View(provincial);
        }

        // GET: Provincials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provincials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "provincial_id,provincial_name,provincial_activate,provincial_dateCreate,provincial_dateEdit,provincial_recycleBin")] Provincial provincial)
        {
            if (ModelState.IsValid)
            {
                db.Provincials.Add(provincial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provincial);
        }

        // GET: Provincials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincial provincial = db.Provincials.Find(id);
            if (provincial == null)
            {
                return HttpNotFound();
            }
            return View(provincial);
        }

        // POST: Provincials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "provincial_id,provincial_name,provincial_activate,provincial_dateCreate,provincial_dateEdit,provincial_recycleBin")] Provincial provincial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provincial);
        }

        // GET: Provincials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincial provincial = db.Provincials.Find(id);
            if (provincial == null)
            {
                return HttpNotFound();
            }
            return View(provincial);
        }

        // POST: Provincials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincial provincial = db.Provincials.Find(id);
            db.Provincials.Remove(provincial);
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
