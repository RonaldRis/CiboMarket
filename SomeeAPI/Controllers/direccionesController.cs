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
    public class direccionesController : ApiController
    {
        private cibodbxamarinfinalEntities db = new cibodbxamarinfinalEntities();

        // GET: api/direcciones
        public IQueryable<direcciones> Getdirecciones()
        {
            return db.direcciones;
        }

        // GET: api/direcciones/5
        [ResponseType(typeof(direcciones))]
        public IHttpActionResult Getdirecciones(int id)
        {
            direcciones direcciones = db.direcciones.Find(id);
            if (direcciones == null)
            {
                return NotFound();
            }

            return Ok(direcciones);
        }

        // PUT: api/direcciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdirecciones(int id, direcciones direcciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != direcciones.idDir)
            {
                return BadRequest();
            }

            db.Entry(direcciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!direccionesExists(id))
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

        // POST: api/direcciones
        [ResponseType(typeof(direcciones))]
        public IHttpActionResult Postdirecciones(direcciones direcciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.direcciones.Add(direcciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = direcciones.idDir }, direcciones);
        }

        // DELETE: api/direcciones/5
        [ResponseType(typeof(direcciones))]
        public IHttpActionResult Deletedirecciones(int id)
        {
            direcciones direcciones = db.direcciones.Find(id);
            if (direcciones == null)
            {
                return NotFound();
            }

            db.direcciones.Remove(direcciones);
            db.SaveChanges();

            return Ok(direcciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool direccionesExists(int id)
        {
            return db.direcciones.Count(e => e.idDir == id) > 0;
        }
    }
}