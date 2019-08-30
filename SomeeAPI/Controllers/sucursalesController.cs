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
    public class sucursalesController : ApiController
    {
        private cibodbxamarinfinalEntities db = new cibodbxamarinfinalEntities();

        // GET: api/sucursales
        public IQueryable<sucursales> Getsucursales()
        {
            return db.sucursales;
        }

        // GET: api/sucursales/5
        [ResponseType(typeof(sucursales))]
        public IHttpActionResult Getsucursales(int id)
        {
            sucursales sucursales = db.sucursales.Find(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            return Ok(sucursales);
        }

        // PUT: api/sucursales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsucursales(int id, sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursales.idSucursal)
            {
                return BadRequest();
            }

            db.Entry(sucursales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sucursalesExists(id))
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

        // POST: api/sucursales
        [ResponseType(typeof(sucursales))]
        public IHttpActionResult Postsucursales(sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sucursales.Add(sucursales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sucursales.idSucursal }, sucursales);
        }

        // DELETE: api/sucursales/5
        [ResponseType(typeof(sucursales))]
        public IHttpActionResult Deletesucursales(int id)
        {
            sucursales sucursales = db.sucursales.Find(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            db.sucursales.Remove(sucursales);
            db.SaveChanges();

            return Ok(sucursales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sucursalesExists(int id)
        {
            return db.sucursales.Count(e => e.idSucursal == id) > 0;
        }
    }
}