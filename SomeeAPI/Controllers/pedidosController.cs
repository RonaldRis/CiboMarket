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
    public class pedidosController : ApiController
    {
        private cibodbxamarinfinalEntities db = new cibodbxamarinfinalEntities();

        // GET: api/pedidos
        public IQueryable<pedidos> Getpedidos()
        {
            return db.pedidos;
        }

        // GET: api/pedidos/5
        [ResponseType(typeof(pedidos))]
        public IHttpActionResult Getpedidos(int id)
        {

            var resultados = from c in db.pedidos
                             select new
                             {
                                 idUser = c.idUser,
                                 idRepartidor = c.idRepartidor,
                                 fecha = c.fecha,
                                 hora = c.hora,
                                 total = c.total,
                                 xlat = c.xlat,
                                 ylat = c.ylat,
                                 comentarios = c.comentarios,
                                 estado = c.estado,
                                 puntajeServicio = c.puntajeServicio,
                                 metodoPago = c.metodoPago
                             };

            if (resultados == null)
            {
                return NotFound();
            }
            return Ok(resultados);

            //pedidos pedidos = db.pedidos.Find(id);
            //if (pedidos == null)
            //{
            //    return NotFound();
            //}

            //return Ok(pedidos);
        }

        // PUT: api/pedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpedidos(int id, pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedidos.idPedido)
            {
                return BadRequest();
            }

            db.Entry(pedidos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pedidosExists(id))
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

        // POST: api/pedidos
        [ResponseType(typeof(pedidos))]
        public IHttpActionResult Postpedidos(pedidos pedidos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pedidos.Add(pedidos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pedidos.idPedido }, pedidos);
        }

        // DELETE: api/pedidos/5
        [ResponseType(typeof(pedidos))]
        public IHttpActionResult Deletepedidos(int id)
        {
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            db.pedidos.Remove(pedidos);
            db.SaveChanges();

            return Ok(pedidos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pedidosExists(int id)
        {
            return db.pedidos.Count(e => e.idPedido == id) > 0;
        }
    }
}