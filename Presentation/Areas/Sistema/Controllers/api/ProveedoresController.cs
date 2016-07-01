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
    public class ProveedoresController : ApiController
    {
        private SupplierBL supplierBL = new SupplierBL();
        // GET: api/Proveedores
        public IEnumerable<Supplier> Get()
        {
            return supplierBL.GetAll();
        }

        // GET: api/Proveedores/5
        public Supplier Get(string id)
        {
            return supplierBL.Find(id);
        }

        // POST: api/Proveedores
        public HttpResponseMessage Post(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplierBL.Create(supplier);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
        }

        // PUT: api/Proveedores/5
        public HttpResponseMessage Put(string id, Supplier supplier)
        {
            if (id != supplier.SupplierID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            supplierBL.Update(supplier);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Proveedores/5
        public HttpResponseMessage Delete(string id)
        {
            var supplier = supplierBL.Find(id);
            if (supplier!= null)
            {
                var response = supplierBL.Delete(supplier);
                if (response)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.Conflict, "Algunos productos dependen de este proveedor");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
