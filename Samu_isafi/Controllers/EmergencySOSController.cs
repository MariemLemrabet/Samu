using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace Samu_isafi.Controllers
{
    public class EmergencySOSController : ApiController
    {
        private samuEntities1 context;

        public EmergencySOSController()
        {
            context = new samuEntities1();
        }

        // GET api/emergencysos
        [HttpGet]
        public IEnumerable<emergysos> GetAllEmergencySOS()
        {
            try
            {
                return context.emergysos.ToList();
            }
            catch (Exception ex)
            {
                // Gérer l'exception comme requis (journalisation, traitement, etc.)
                throw; // Renvoyer l'exception pour la propager à l'appelant
            }
        }

        // GET api/emergencysos/{id}
        [HttpGet]
        public IHttpActionResult GetEmergencySOSById(int id)
        {
            var emergencySOS = context.emergysos.FirstOrDefault(es => es.id == id);
            if (emergencySOS == null)
            {
                return NotFound();
            }
            return Ok(emergencySOS);
        }

        // POST api/emergencysos
        [HttpPost]
        public IHttpActionResult CreateEmergencySOS(emergysos emergencySOS)
        {
            context.emergysos.Add(emergencySOS);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emergencySOS.id }, emergencySOS);
        }

        // PUT api/emergencysos/{id}
        [HttpPut]
        public IHttpActionResult UpdateEmergencySOS(int id, emergysos updatedEmergencySOS)
        {
            var emergencySOS = context.emergysos.FirstOrDefault(es => es.id == id);
            if (emergencySOS == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'Emergency SOS avec les valeurs fournies
            emergencySOS.createBy = updatedEmergencySOS.createBy;
            emergencySOS.phoneNumber = updatedEmergencySOS.phoneNumber;
            emergencySOS.namePatient = updatedEmergencySOS.namePatient;
            emergencySOS.address = updatedEmergencySOS.address;

            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/emergencysos/{id}
        [HttpDelete]
        public IHttpActionResult DeleteEmergencySOS(int id)
        {
            var emergencySOS = context.emergysos.FirstOrDefault(es => es.id == id);
            if (emergencySOS == null)
            {
                return NotFound();
            }

            context.emergysos.Remove(emergencySOS);
            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
