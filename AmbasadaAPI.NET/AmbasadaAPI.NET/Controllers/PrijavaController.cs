using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AmbasadaAPI.NET.Models;

namespace AmbasadaAPI.NET.Controllers
{
    public class PrijavaController : ApiController
    {
        private AmbasadaModel db = new AmbasadaModel();

        // GET: api/Prijava
        public IQueryable<Prijava> GetPrijavas()
        {
            return db.Prijavas;
        }

        // GET: api/Prijava/5
        [ResponseType(typeof(Prijava))]
        public IHttpActionResult GetPrijava(int id)
        {
            Prijava prijava = db.Prijavas.Find(id);
            if (prijava == null)
            {
                return NotFound();
            }

            return Ok(prijava);
        }

        // PUT: api/Prijava/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrijava(int id, Prijava prijava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prijava.id)
            {
                return BadRequest();
            }

            db.Entry(prijava).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrijavaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Prijava
        [ResponseType(typeof(Prijava))]
        public IHttpActionResult PostPrijava(Prijava prijava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prijavas.Add(prijava);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prijava.id }, prijava);
        }

        // DELETE: api/Prijava/5
        [ResponseType(typeof(Prijava))]
        public IHttpActionResult DeletePrijava(int id)
        {
            Prijava prijava = db.Prijavas.Find(id);
            if (prijava == null)
            {
                return NotFound();
            }

            db.Prijavas.Remove(prijava);
            db.SaveChanges();

            return Ok(prijava);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrijavaExists(int id)
        {
            return db.Prijavas.Count(e => e.id == id) > 0;
        }
    }
}