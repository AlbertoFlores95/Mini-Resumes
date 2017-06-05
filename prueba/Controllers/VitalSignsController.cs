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
using Web.Models;

namespace prueba.Controllers
{
    public class VitalSignsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/VitalSigns
        public IQueryable<VitalSigns> GetPersons()
        {
            return db.Persons;
        }

        // GET: api/VitalSigns/5
        [ResponseType(typeof(VitalSigns))]
        public IHttpActionResult GetVitalSigns(int id)
        {
            VitalSigns vitalSigns = db.Persons.Find(id);
            if (vitalSigns == null)
            {
                return NotFound();
            }

            return Ok(vitalSigns);
        }

        // PUT: api/VitalSigns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVitalSigns(int id, VitalSigns vitalSigns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vitalSigns.ID)
            {
                return BadRequest();
            }

            db.Entry(vitalSigns).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VitalSignsExists(id))
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

        // POST: api/VitalSigns
        [ResponseType(typeof(VitalSigns))]
        public IHttpActionResult PostVitalSigns(VitalSigns vitalSigns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persons.Add(vitalSigns);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vitalSigns.ID }, vitalSigns);
        }

        // DELETE: api/VitalSigns/5
        [ResponseType(typeof(VitalSigns))]
        public IHttpActionResult DeleteVitalSigns(int id)
        {
            VitalSigns vitalSigns = db.Persons.Find(id);
            if (vitalSigns == null)
            {
                return NotFound();
            }

            db.Persons.Remove(vitalSigns);
            db.SaveChanges();

            return Ok(vitalSigns);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VitalSignsExists(int id)
        {
            return db.Persons.Count(e => e.ID == id) > 0;
        }
    }
}