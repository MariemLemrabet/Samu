using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace Samu_isafi.Controllers
{
    public class EmergencyCategoryController : ApiController
    {
        private samuEntities1 context;

        public EmergencyCategoryController()
        {
            context = new samuEntities1();
        }

        // GET api/emergencycategory
        [HttpGet]
        public IEnumerable<emergencycategory> GetAllCategories()
        {
            try
            {
                return context.emergencycategory.ToList();
            }
            catch (Exception ex)
            {
                // Gérer l'exception comme requis (journalisation, traitement, etc.)
                throw; // Renvoyer l'exception pour la propager à l'appelant
            }
        }

        // GET api/emergencycategory/{id}
        [HttpGet]
        public IHttpActionResult GetCategoryById(string id)
        {
            var category = context.emergencycategory.FirstOrDefault(c => c.id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/emergencycategory
        [HttpPost]
        public IHttpActionResult CreateCategory(emergencycategory category)
        {
            context.emergencycategory.Add(category);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.id }, category);
        }

        // PUT api/emergencycategory/{id}
        [HttpPut]
        public IHttpActionResult UpdateCategory(string id, emergencycategory updatedCategory)
        {
            var category = context.emergencycategory.FirstOrDefault(c => c.id == id);
            if (category == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de la catégorie avec les valeurs fournies
            category.name = updatedCategory.name;
            category.description = updatedCategory.description;

            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/emergencycategory/{id}
        [HttpDelete]
        public IHttpActionResult DeleteCategory(string id)
        {
            var category = context.emergencycategory.FirstOrDefault(c => c.id == id);
            if (category == null)
            {
                return NotFound();
            }

            context.emergencycategory.Remove(category);
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
