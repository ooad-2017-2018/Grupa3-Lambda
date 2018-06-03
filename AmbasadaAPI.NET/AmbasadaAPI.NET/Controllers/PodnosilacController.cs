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
    public class PodnosilacController : ApiController
    {
        private AmbasadaModel db = new AmbasadaModel();

        // GET: api/Podnosilac
        public IQueryable<Podnosilac> GetPodnosilacs()
        {
            return db.Podnosilacs;
        }

        // GET: api/Podnosilac/5
        [ResponseType(typeof(Podnosilac))]
        public IHttpActionResult GetPodnosilac(int id)
        {
            Podnosilac podnosilac = db.Podnosilacs.Find(id);
            if (podnosilac == null)
            {
                return NotFound();
            }

            return Ok(podnosilac);
        }

        // PUT: api/Podnosilac/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPodnosilac(int id, Podnosilac podnosilac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != podnosilac.id)
            {
                return BadRequest();
            }

            db.Entry(podnosilac).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PodnosilacExists(id))
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

        // POST: api/Podnosilac
        [ResponseType(typeof(Podnosilac))]
        public IHttpActionResult PostPodnosilac(Podnosilac podnosilac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Prijava prijava = new Prijava();
            prijava.vrijemePrijave = DateTime.Now;
            prijava.stanjePrijave = false;
            prijava.izdataPrijava = false;
            prijava.Podnosilac = podnosilac;
            podnosilac.Prijava = prijava;

            db.Podnosilacs.Add(podnosilac);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = podnosilac.id }, podnosilac);
        }

        // DELETE: api/Podnosilac/5
        [ResponseType(typeof(Podnosilac))]
        public IHttpActionResult DeletePodnosilac(int id)
        {
            Podnosilac podnosilac = db.Podnosilacs.Find(id);
            if (podnosilac == null)
            {
                return NotFound();
            }

            db.Podnosilacs.Remove(podnosilac);
            db.SaveChanges();

            return Ok(podnosilac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PodnosilacExists(int id)
        {
            return db.Podnosilacs.Count(e => e.id == id) > 0;
        }
    }
}