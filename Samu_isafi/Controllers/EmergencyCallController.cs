using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace Samu_isafi.Controllers
{
    public class EmergencyCallController : ApiController
    {
        private samuEntities1 context;

        public EmergencyCallController()
        {
            context = new samuEntities1();
        }

        // GET api/emergencycall
        [HttpGet]
        public IEnumerable<emergencycall> GetAllEmergencyCalls()
        {
            try
            {
                return context.emergencycall.ToList();
            }
            catch (Exception ex)
            {
                // Gérer l'exception comme requis (journalisation, traitement, etc.)
                throw; // Renvoyer l'exception pour la propager à l'appelant
            }
        }

        // GET api/emergencycall/{id}
        [HttpGet]
        public IHttpActionResult GetEmergencyCallById(int id)
        {
            var emergencyCall = context.emergencycall.FirstOrDefault(e => e.id == id);
            if (emergencyCall == null)
            {
                return NotFound();
            }
            return Ok(emergencyCall);
        }

        // POST api/emergencycall
        [HttpPost]
        public IHttpActionResult CreateEmergencyCall(emergencycall emergencyCall)
        {
            context.emergencycall.Add(emergencyCall);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emergencyCall.id }, emergencyCall);
        }

        // PUT api/emergencycall/{id}
        [HttpPut]
        public IHttpActionResult UpdateEmergencyCall(int id, emergencycall updatedEmergencyCall)
        {
            var emergencyCall = context.emergencycall.FirstOrDefault(e => e.id == id);
            if (emergencyCall == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'appel d'urgence avec les valeurs fournies
            emergencyCall.patientName = updatedEmergencyCall.patientName;
            emergencyCall.description = updatedEmergencyCall.description;
            emergencyCall.status = updatedEmergencyCall.status;
            emergencyCall.createAt = updatedEmergencyCall.createAt;
            emergencyCall.isByCall = updatedEmergencyCall.isByCall;
            emergencyCall.addBy = updatedEmergencyCall.addBy;
            emergencyCall.createBy = updatedEmergencyCall.createBy;
            emergencyCall.phoneNumber = updatedEmergencyCall.phoneNumber;
            emergencyCall.address = updatedEmergencyCall.address;
            emergencyCall.sex = updatedEmergencyCall.sex;
            emergencyCall.patientType = updatedEmergencyCall.patientType;
            emergencyCall.patientCount = updatedEmergencyCall.patientCount;
            emergencyCall.accidentType = updatedEmergencyCall.accidentType;
            emergencyCall.subCategoryId = updatedEmergencyCall.subCategoryId;

            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE api/emergencycall/{id}
        [HttpDelete]
        public IHttpActionResult DeleteEmergencyCall(int id)
        {
            var emergencyCall = context.emergencycall.FirstOrDefault(e => e.id == id);
            if (emergencyCall == null)
            {
                return NotFound();
            }

            context.emergencycall.Remove(emergencyCall);
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
