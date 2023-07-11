using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace Samu_isafi.Controllers
{
    public class AdresseController : ApiController
    {
        private samuEntities1 context;

        public AdresseController()
        {
            context = new samuEntities1();
        }

        // GET api/adresse
        [HttpGet]
        public IEnumerable<adresse> GetAllAdresses()
        {
            try
            {
                return context.adresse.ToList();
            }
            catch (Exception ex)
            {
                // Gérer l'exception comme requis (journalisation, traitement, etc.)
                throw; // Renvoyer l'exception pour la propager à l'appelant
            }
        }

        // GET api/adresse/{id}
        [HttpGet]
        public IHttpActionResult GetAdresseById(int id)
        {
            var adresse = context.adresse.FirstOrDefault(a => a.id == id);
            if (adresse == null)
            {
                return NotFound();
            }
            return Ok(adresse);
        }

        // POST api/adresse
        [HttpPost]
        public IHttpActionResult CreateAdresse(adresse adresse)
        {
            context.adresse.Add(adresse);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adresse.id }, adresse);
        }

        // PUT api/adresse/{id}
        [HttpPut]
        public IHttpActionResult UpdateAdresse(int id, adresse updatedAdresse)
        {
            var adresse = context.adresse.FirstOrDefault(a => a.id == id);
            if (adresse == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'Adresse avec les valeurs fournies
            adresse.address = updatedAdresse.address;
            adresse.latitude = updatedAdresse.latitude;
            adresse.longitude = updatedAdresse.longitude;

            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/adresse/{id}
        [HttpDelete]
        public IHttpActionResult DeleteAdresse(int id)
        {
            var adresse = context.adresse.FirstOrDefault(a => a.id == id);
            if (adresse == null)
            {
                return NotFound();
            }

            context.adresse.Remove(adresse);
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
