using CoreBussines;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category() { CategoryId = 1, Name = "Beverage" , Description ="Beverage" },
                new Category() { CategoryId = 2, Name = "Bakery" , Description ="Bakery" },
                new Category() { CategoryId = 3, Name = "Meat" , Description ="Meat" },                
            };


        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            var maxId = categories.Count() > 0 ? categories.Max(x => x.CategoryId) : 0;
            category.CategoryId = maxId + 1;
            categories.Add(category);
        }

        public  async Task DeleteCategory(int categoryId)
        {
            categories?.Remove(GetCategoryById(categoryId));
            
        }

        public void EditCategory(Category category)
        {
            var categoryUpdate = categories?.FirstOrDefault(x => x.CategoryId == category.CategoryId);

            if(categoryUpdate != null)
            {
                categoryUpdate = category;
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            
            return categories;
        }

        public Category GetCategoryById(int categoryId) => categories?.FirstOrDefault(x => x.CategoryId == categoryId);
    }
}