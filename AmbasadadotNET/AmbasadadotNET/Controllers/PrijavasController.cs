using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmbasadadotNET.Models;

namespace AmbasadadotNET.Controllers
{
    public class PrijavasController : Controller
    {
        private AmbasadaContext db = new AmbasadaContext();

        // GET: Prijavas
        public ActionResult Index()
        {
            return View(db.prijave.ToList());
        }

        // GET: Prijavas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.prijave.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // GET: Prijavas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prijavas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,vrijemePrijave,stanjePrijave")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.prijave.Add(prijava);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prijava);
        }

        // GET: Prijavas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.prijave.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // POST: Prijavas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,vrijemePrijave,stanjePrijave")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prijava);
        }

        // GET: Prijavas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.prijave.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // POST: Prijavas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prijava prijava = db.prijave.Find(id);
            db.prijave.Remove(prijava);
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
