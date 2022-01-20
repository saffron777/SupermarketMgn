using CoreBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext db;

        public CategoryRepository(MarketContext db)
        {
            this.db = db;
        }
        public void AddCategory(Category category)
        {
            db.categories.Add(category);
            db.SaveChanges();
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await db.categories.FindAsync(categoryId);

            if(category == null)
                return;

            db.categories.Remove(category);
            db.SaveChanges();
        }

        public void EditCategory(Category category)
        {
            var cat = db.categories.Find(category.CategoryId);

            if(cat == null)
                return ;

            cat.Name = category.Name;
            cat.Description = category.Description;

            db.SaveChanges();

        }

        public IEnumerable<Category> GetCategories()
        {
            return db.categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return db.categories.FirstOrDefault(x => x.CategoryId == categoryId);
        }
    }
}
