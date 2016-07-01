using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Entity;
namespace Presentation.Areas.Sistema.Controllers.api
{
    [Authorize]
    public class ProductosController : ApiController
    {
        private ProductBL productBL = new ProductBL();
        // GET: api/Productos
        public IEnumerable<Product> Get()
        {
            return productBL.GetAll();
        }

        // GET: api/Productos/5
        public Product Get(string id)
        {
            return productBL.Find(id);
        }

        // POST: api/Productos
        public HttpResponseMessage Post(Product product)
        {
            if (ModelState.IsValid)
            {
                productBL.Create(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/Productos/5
        public HttpResponseMessage Put(string id,Product product)
        {
            if (id != product.ProductID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                productBL.Update(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            
        }

        // DELETE: api/Productos/5
        public HttpResponseMessage Delete(string id)
        {
            var product = productBL.Find(id);
            if (product!= null)
            {
                productBL.Delete(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
