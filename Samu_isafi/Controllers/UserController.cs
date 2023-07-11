using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Samu_isafi.Controllers
{
    public class UserController : ApiController
    {
        private samuEntities1 context;

        public UserController()
        {
            context = new samuEntities1();
        }

        // GET api/user
        [HttpGet]
        public IEnumerable<usermodel> GetAllUsers()
        {
            try
            {
                return context.usermodel.ToList();
            }
            catch (Exception ex)
            {
                // Gérer l'exception comme requis (journalisation, traitement, etc.)
                throw; // Renvoyer l'exception pour la propager à l'appelant
            }
        }

        // GET api/user/{id}
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            var user = context.usermodel.FirstOrDefault(u => u.id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public IHttpActionResult CreateUser(usermodel userModel)
        {
            context.usermodel.Add(userModel);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userModel.id }, userModel);
        }

        // PUT api/user/{id}
        [HttpPut]
        public IHttpActionResult UpdateUser(int id, usermodel updatedUser)
        {
            var user = context.usermodel.FirstOrDefault(u => u.id == id);
            if (user == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'utilisateur avec les valeurs fournies
            user.email = updatedUser.email;
            user.password = updatedUser.password;
            user.fullName = updatedUser.fullName;
            user.phoneNumber = updatedUser.phoneNumber;
            user.role = updatedUser.role;
            user.token = updatedUser.token;
            user.createAt = updatedUser.createAt;
            user.updateAt = updatedUser.updateAt;

            context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE api/user/{id}
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = context.usermodel.FirstOrDefault(u => u.id == id);
            if (user == null)
            {
                return NotFound();
            }

            context.usermodel.Remove(user);
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
