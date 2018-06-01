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
    public class PodnosilacsController : Controller
    {
        private AmbasadaContext db = new AmbasadaContext();

        // GET: Podnosilacs
        public ActionResult Index()
        {
            return View(db.podnosioci.ToList());
        }

        // GET: Podnosilacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podnosilac podnosilac = db.podnosioci.Find(id);
            if (podnosilac == null)
            {
                return HttpNotFound();
            }
            return View(podnosilac);
        }

        // GET: Podnosilacs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Podnosilacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv,email,datumRodjenja,jmbg,dodatneInformacije,mjestoPrebivalista")] Podnosilac podnosilac)
        {
            if (ModelState.IsValid)
            {
                db.podnosioci.Add(podnosilac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podnosilac);
        }

        // GET: Podnosilacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podnosilac podnosilac = db.podnosioci.Find(id);
            if (podnosilac == null)
            {
                return HttpNotFound();
            }
            return View(podnosilac);
        }

        // POST: Podnosilacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv,email,datumRodjenja,jmbg,dodatneInformacije,mjestoPrebivalista")] Podnosilac podnosilac)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podnosilac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podnosilac);
        }

        // GET: Podnosilacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podnosilac podnosilac = db.podnosioci.Find(id);
            if (podnosilac == null)
            {
                return HttpNotFound();
            }
            return View(podnosilac);
        }

        // POST: Podnosilacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Podnosilac podnosilac = db.podnosioci.Find(id);
            db.podnosioci.Remove(podnosilac);
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
