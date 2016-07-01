using Entity;
using Repository;
using System;
using System.Collections.Generic;

namespace Business
{
    public class ProductBL
    {
        IRepository repo = new Business.Repository();
        public IEnumerable<Product> GetAll()
        {
            return repo.GetAll<Product>();
        }
        public Product Find(string id)
        {
            return repo.FindEntity<Product>(x => x.ProductID == id, "Category", "Supplier");
        }
        public Product Create(Product newProduct)
        {
            newProduct.ProductID = Guid.NewGuid().ToString();
            return repo.Create(newProduct);
        }
        public bool Update(Product modifiedProduct)
        {
            return repo.Update(modifiedProduct);
        }
        public bool Delete(Product deletedProduct)
        {
            return repo.Delete(deletedProduct);
        }
    }
}
