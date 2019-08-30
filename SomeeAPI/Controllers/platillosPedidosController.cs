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
    public class platillosPedidosController : ApiController
    {
        private cibodbxamarinfinalEntities db = new cibodbxamarinfinalEntities();

        // GET: api/platillosPedidos
        public IQueryable<platillosPedidos> GetplatillosPedidos()
        {
            return db.platillosPedidos;
        }

        // GET: api/platillosPedidos/5
        [ResponseType(typeof(platillosPedidos))]
        public IHttpActionResult GetplatillosPedidos(int id)
        {
            platillosPedidos platillosPedidos = db.platillosPedidos.Find(id);
            if (platillosPedidos == null)
            {
                return NotFound();
            }

            return Ok(platillosPedidos);
        }

        // PUT: api/platillosPedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutplatillosPedidos(int id, platillosPedidos platillosPedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platillosPedidos.idPlatPed)
            {
                return BadRequest();
            }

            db.Entry(platillosPedidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!platillosPedidosExists(id))
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

        // POST: api/platillosPedidos
        [ResponseType(typeof(platillosPedidos))]
        public IHttpActionResult PostplatillosPedidos(platillosPedidos platillosPedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.platillosPedidos.Add(platillosPedidos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = platillosPedidos.idPlatPed }, platillosPedidos);
        }

        // DELETE: api/platillosPedidos/5
        [ResponseType(typeof(platillosPedidos))]
        public IHttpActionResult DeleteplatillosPedidos(int id)
        {
            platillosPedidos platillosPedidos = db.platillosPedidos.Find(id);
            if (platillosPedidos == null)
            {
                return NotFound();
            }

            db.platillosPedidos.Remove(platillosPedidos);
            db.SaveChanges();

            return Ok(platillosPedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool platillosPedidosExists(int id)
        {
            return db.platillosPedidos.Count(e => e.idPlatPed == id) > 0;
        }
    }
}