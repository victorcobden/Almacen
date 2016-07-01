using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation.Areas.Sistema.Controllers.api
{
    public class UsuariosController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Usuarios
        public IEnumerable<ApplicationUser> Get()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            return userManager.Users.ToList();
        }

        // GET: api/Usuarios/5
        public ApplicationUser Get(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            return userManager.FindById(id);
        }

        // POST: api/Usuarios
        public HttpResponseMessage Post(ApplicationUser user)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (userManager.FindByName(user.Email) == null)
            {
                var newUser = new ApplicationUser
                {
                    UserName = user.Email,
                    Email = user.Email
                };
                try
                {
                    userManager.Create(newUser, newUser.Email);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        // PUT: api/Usuarios/5
        public HttpResponseMessage Put(string id, ApplicationUser user)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            if (id != user.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                user.UserName = user.Email;
                userManager.Update(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // DELETE: api/Usuarios/5
        public HttpResponseMessage Delete(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindById(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                userManager.Delete(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
