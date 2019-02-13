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
using ticTac1.model;

namespace ticTac1.controllers
{
    public class TicgamesController : ApiController
    {
        private gameEntities db = new gameEntities();

        // GET: api/Ticgames
        public IQueryable<Ticgame> GetTicgames()
        {
            return db.Ticgames;
        }

        // GET: api/Ticgames/5
        [ResponseType(typeof(Ticgame))]
        public IHttpActionResult GetTicgame(string id)
        {
            Ticgame ticgame = db.Ticgames.Find(id);
            if (ticgame == null)
            {
                return NotFound();
            }

            return Ok(ticgame);
        }

        // PUT: api/Ticgames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicgame(string id, Ticgame ticgame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticgame.Email)
            {
                return BadRequest();
            }

            db.Entry(ticgame).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicgameExists(id))
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

        // POST: api/Ticgames
        [ResponseType(typeof(Ticgame))]
        public IHttpActionResult PostTicgame(Ticgame ticgame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ticgames.Add(ticgame);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TicgameExists(ticgame.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticgame.Email }, ticgame);
        }

        // DELETE: api/Ticgames/5
        [ResponseType(typeof(Ticgame))]
        public IHttpActionResult DeleteTicgame(string id)
        {
            Ticgame ticgame = db.Ticgames.Find(id);
            if (ticgame == null)
            {
                return NotFound();
            }

            db.Ticgames.Remove(ticgame);
            db.SaveChanges();

            return Ok(ticgame);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicgameExists(string id)
        {
            return db.Ticgames.Count(e => e.Email == id) > 0;
        }
    }
}