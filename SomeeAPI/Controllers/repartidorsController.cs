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
using SomeeAPI.Models;

namespace SomeeAPI.Controllers
{
    public class repartidorsController : ApiController
    {
        private cibodbxamarinfinalEntities db = new cibodbxamarinfinalEntities();

        // GET: api/repartidors
        public IQueryable<repartidor> Getrepartidor()
        {
            return db.repartidor;
        }

        // GET: api/repartidors/5
        [ResponseType(typeof(repartidor))]
        public IHttpActionResult Getrepartidor(int id)
        {
            repartidor repartidor = db.repartidor.Find(id);
            if (repartidor == null)
            {
                return NotFound();
            }

            return Ok(repartidor);
        }

        // PUT: api/repartidors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putrepartidor(int id, repartidor repartidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repartidor.idRepartidor)
            {
                return BadRequest();
            }

            db.Entry(repartidor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repartidorExists(id))
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

        // POST: api/repartidors
        [ResponseType(typeof(repartidor))]
        public IHttpActionResult Postrepartidor(repartidor repartidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.repartidor.Add(repartidor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = repartidor.idRepartidor }, repartidor);
        }

        // DELETE: api/repartidors/5
        [ResponseType(typeof(repartidor))]
        public IHttpActionResult Deleterepartidor(int id)
        {
            repartidor repartidor = db.repartidor.Find(id);
            if (repartidor == null)
            {
                return NotFound();
            }

            db.repartidor.Remove(repartidor);
            db.SaveChanges();

            return Ok(repartidor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool repartidorExists(int id)
        {
            return db.repartidor.Count(e => e.idRepartidor == id) > 0;
        }
    }
}