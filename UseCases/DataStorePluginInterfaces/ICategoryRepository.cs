using CoreBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();
        public void AddCategory(Category category);
        void EditCategory(Category category);
        Category GetCategoryById(int categoryId);
        Task DeleteCategory(int categoryId);
    }
}
