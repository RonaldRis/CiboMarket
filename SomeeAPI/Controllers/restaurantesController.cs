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
    public class restaurantesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/restaurantes
        public IQueryable<restaurante> Getrestaurante()
        {
            return db.restaurante;
        }

        // GET: api/restaurantes/5
        [ResponseType(typeof(restaurante))]
        public IHttpActionResult Getrestaurante(int id)
        {
            restaurante restaurante = db.restaurante.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return Ok(restaurante);
        }

        // PUT: api/restaurantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putrestaurante(int id, restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurante.idRes)
            {
                return BadRequest();
            }

            db.Entry(restaurante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!restauranteExists(id))
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

        // POST: api/restaurantes
        [ResponseType(typeof(restaurante))]
        public IHttpActionResult Postrestaurante(restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.restaurante.Add(restaurante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurante.idRes }, restaurante);
        }

        // DELETE: api/restaurantes/5
        [ResponseType(typeof(restaurante))]
        public IHttpActionResult Deleterestaurante(int id)
        {
            restaurante restaurante = db.restaurante.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            db.restaurante.Remove(restaurante);
            db.SaveChanges();

            return Ok(restaurante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool restauranteExists(int id)
        {
            return db.restaurante.Count(e => e.idRes == id) > 0;
        }
    }
}