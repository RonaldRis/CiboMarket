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
    public class platillosController : ApiController
    {
        private cibodbxamarinfinalEntities db = new cibodbxamarinfinalEntities();

        // GET: api/platillos
        public IQueryable<platillos> Getplatillos()
        {
            return db.platillos;
        }

        // GET: api/platillos/5
        [ResponseType(typeof(platillos))]
        public IHttpActionResult Getplatillos(int id)
        {
            platillos platillos = db.platillos.Find(id);
            if (platillos == null)
            {
                return NotFound();
            }

            return Ok(platillos);
        }

        // PUT: api/platillos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putplatillos(int id, platillos platillos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platillos.idPlatillo)
            {
                return BadRequest();
            }

            db.Entry(platillos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!platillosExists(id))
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

        // POST: api/platillos
        [ResponseType(typeof(platillos))]
        public IHttpActionResult Postplatillos(platillos platillos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.platillos.Add(platillos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = platillos.idPlatillo }, platillos);
        }

        // DELETE: api/platillos/5
        [ResponseType(typeof(platillos))]
        public IHttpActionResult Deleteplatillos(int id)
        {
            platillos platillos = db.platillos.Find(id);
            if (platillos == null)
            {
                return NotFound();
            }

            db.platillos.Remove(platillos);
            db.SaveChanges();

            return Ok(platillos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool platillosExists(int id)
        {
            return db.platillos.Count(e => e.idPlatillo == id) > 0;
        }
    }
}