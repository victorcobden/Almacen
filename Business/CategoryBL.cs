using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using DAL;
using Entity;
namespace Business
{
    public class CategoryBL
    {
        IRepository repo = new Business.Repository();
        public IEnumerable<Category> GetAll()
        {
            return repo.GetAll<Category>();
        }
        public Category Find(string id)
        {
            return repo.FindEntity<Category>(x => x.CategoryID == id);
        }
        public Category Create(Category newCategory)
        {
            newCategory.CategoryID = Guid.NewGuid().ToString();
            return repo.Create(newCategory);
        }
        public bool Update(Category modifiedCategory)
        {
            return repo.Update(modifiedCategory);
        }
        public bool Delete(Category deletedCategory)
        {
            return repo.Delete(deletedCategory);
        }
    }
}
