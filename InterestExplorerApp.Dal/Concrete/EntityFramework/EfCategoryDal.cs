using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestExplorerApp.Dal.Abstract;
using InterestExplorerApp.Entities.Concrete;
namespace InterestExplorerApp.Dal.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        private InterestExplorerContext context = new InterestExplorerContext();

        public void Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            var deletedCategory = context.Categories.SingleOrDefault(x => x.Id == categoryId);
            context.Categories.Remove(deletedCategory);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.Categories.Include("MainCategory").ToList();
        }

       

    public Category GetById(int categoryId)
    {
        return context.Categories.SingleOrDefault(x => x.Id == categoryId);
    }

    public void Update(Category category)
    {

    }
}
}
