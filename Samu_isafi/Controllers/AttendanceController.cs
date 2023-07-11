using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace Samu_isafi.Controllers
{
    public class AttendanceController : ApiController
    {
        private samuEntities1 context;

        public AttendanceController()
        {
            context = new samuEntities1();
        }

        // GET api/attendance
        [HttpGet]
        public IEnumerable<attendance> GetAllAttendances()
        {
            try
            {
                return context.attendance.ToList();
            }
            catch (Exception ex)
            {
                // Gérer l'exception comme requis (journalisation, traitement, etc.)
                throw; // Renvoyer l'exception pour la propager à l'appelant
            }
        }

        // GET api/attendance/{id}
        [HttpGet]
        public IHttpActionResult GetAttendanceById(int id)
        {
            var attendance = context.attendance.FirstOrDefault(a => a.id == id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        // POST api/attendance
        [HttpPost]
        public IHttpActionResult CreateAttendance(attendance attendance)
        {
            context.attendance.Add(attendance);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = attendance.id }, attendance);
        }

        // PUT api/attendance/{id}
        [HttpPut]
        public IHttpActionResult UpdateAttendance(int id, attendance updatedAttendance)
        {
            var attendance = context.attendance.FirstOrDefault(a => a.id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'Attendance avec les valeurs fournies
            attendance.clockIn = updatedAttendance.clockIn;
            attendance.clockOut = updatedAttendance.clockOut;
            attendance.duration = updatedAttendance.duration;
            attendance.idUser = updatedAttendance.idUser;
            attendance.status = updatedAttendance.status;
            attendance.nameUser = updatedAttendance.nameUser;
            attendance.phoneUser = updatedAttendance.phoneUser;
            attendance.position = updatedAttendance.position;

            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/attendance/{id}
        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var attendance = context.attendance.FirstOrDefault(a => a.id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            context.attendance.Remove(attendance);
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
