using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SupplierBL
    {
        IRepository repo = new Business.Repository();
        public IEnumerable<Supplier> GetAll()
        {
            return repo.GetAll<Supplier>();
        }
        public Supplier Find(string id)
        {
            return repo.FindEntity<Supplier>(x => x.SupplierID == id);
        }
        public Supplier Create(Supplier newSupplier)
        {
            newSupplier.SupplierID = Guid.NewGuid().ToString();
            return repo.Create(newSupplier);
        }
        public bool Update(Supplier modifiedSupplier)
        {
            return repo.Update(modifiedSupplier);
        }
        public bool Delete(Supplier deletedSupplier)
        {
            return repo.Delete(deletedSupplier);
        }
    }
}
