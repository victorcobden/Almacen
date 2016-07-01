using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation.Areas.Sistema.Controllers.api
{
    [Authorize]
    public class CategoriasController : ApiController
    {
        private CategoryBL categoryBL = new CategoryBL();
        // GET: api/Categorias
        public IEnumerable<Category> Get()
        {
            return categoryBL.GetAll();
        }

        // GET: api/Categorias/5
        public Category Get(string id)
        {
            return categoryBL.Find(id);
        }

        // POST: api/Categorias
        public HttpResponseMessage Post(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryBL.Create(category);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/Categorias/5
        public HttpResponseMessage Put(string id, Category category)
        {
            if (id != category.CategoryID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                categoryBL.Update(category);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            
        }

        // DELETE: api/Categorias/5
        public HttpResponseMessage Delete(string id)
        {
            var category = categoryBL.Find(id);
            if (category != null)
            {
                categoryBL.Delete(category);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
        }
    }
}
