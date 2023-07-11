using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace Samu_isafi.Controllers
{
    public class MedicalRecordController : ApiController
    {
        private samuEntities1 context;

        public MedicalRecordController()
        {
            context = new samuEntities1();
        }

        // GET api/medicalrecord
        [HttpGet]
        public IEnumerable<medicalrecord> GetAllMedicalRecords()
        {
            try
            {
                return context.medicalrecord.ToList();
            }
            catch (Exception ex)
            {
                // Gérer l'exception comme requis (journalisation, traitement, etc.)
                throw; // Renvoyer l'exception pour la propager à l'appelant
            }
        }

        // GET api/medicalrecord/{id}
        [HttpGet]
        public IHttpActionResult GetMedicalRecordById(int id)
        {
            var medicalRecord = context.medicalrecord.FirstOrDefault(mr => mr.id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return Ok(medicalRecord);
        }

        // POST api/medicalrecord
        [HttpPost]
        public IHttpActionResult CreateMedicalRecord(medicalrecord medicalRecord)
        {
            context.medicalrecord.Add(medicalRecord);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicalRecord.id }, medicalRecord);
        }

        // PUT api/medicalrecord/{id}
        [HttpPut]
        public IHttpActionResult UpdateMedicalRecord(int id, medicalrecord updatedMedicalRecord)
        {
            var medicalRecord = context.medicalrecord.FirstOrDefault(mr => mr.id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés du dossier médical avec les valeurs fournies
            medicalRecord.patientName = updatedMedicalRecord.patientName;
            medicalRecord.dateOfBirth = updatedMedicalRecord.dateOfBirth;
            medicalRecord.bloodType = updatedMedicalRecord.bloodType;
            medicalRecord.iduser = updatedMedicalRecord.iduser;

            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/medicalrecord/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMedicalRecord(int id)
        {
            var medicalRecord = context.medicalrecord.FirstOrDefault(mr => mr.id == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            context.medicalrecord.Remove(medicalRecord);
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
