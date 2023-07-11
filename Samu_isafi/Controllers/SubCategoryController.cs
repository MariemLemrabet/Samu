using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace Samu_isafi.Controllers
{
    public class SubCategoryController : ApiController
    {
        private samuEntities1 context;

        public SubCategoryController()
        {
            context = new samuEntities1();
        }

        // GET api/subcategory
        [HttpGet]
        public IEnumerable<subcategory> GetAllSubCategories()
        {
            try
            {
                return context.subcategory.ToList();
            }
            catch (Exception ex)
            {
                // Gérer l'exception comme requis (journalisation, traitement, etc.)
                throw; // Renvoyer l'exception pour la propager à l'appelant
            }
        }

        // GET api/subcategory/{id}
        [HttpGet]
        public IHttpActionResult GetSubCategoryById(int id)
        {
            var subCategory = context.subcategory.FirstOrDefault(sc => sc.id == id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return Ok(subCategory);
        }

        // POST api/subcategory
        [HttpPost]
        public IHttpActionResult CreateSubCategory(subcategory subCategory)
        {
            context.subcategory.Add(subCategory);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subCategory.id }, subCategory);
        }

        // PUT api/subcategory/{id}
        [HttpPut]
        public IHttpActionResult UpdateSubCategory(int id, subcategory updatedSubCategory)
        {
            var subCategory = context.subcategory.FirstOrDefault(sc => sc.id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de la sous-catégorie avec les valeurs fournies
            subCategory.name = updatedSubCategory.name;
            subCategory.description = updatedSubCategory.description;

            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/subcategory/{id}
        [HttpDelete]
        public IHttpActionResult DeleteSubCategory(int id)
        {
            var subCategory = context.subcategory.FirstOrDefault(sc => sc.id == id);
            if (subCategory == null)
            {
                return NotFound();
            }

            context.subcategory.Remove(subCategory);
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
