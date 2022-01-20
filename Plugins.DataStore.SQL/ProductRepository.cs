using CoreBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductRepository(MarketContext db)
        {
            this.db = db;
        }
        public void AddProduct(Product product)
        {
            db.products.Add(product);
            db.SaveChanges();
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await db.products.FindAsync(productId);

            if (product == null)
                return;

            db.products.Remove(product);
            db.SaveChanges();

        }

        public Product GetProductById(int productId)
        {
            return db.products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.products.ToList();
        }

        public IEnumerable<Product> ProductsByCategoryId(int categoryId)
        {
            return db.products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = db.products.Find(product.ProductId);

            if(prod == null)
                return ;

            prod.CategoryId = product.CategoryId;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            prod.Name = product.Name;

            db.SaveChanges();
        }
    }
}
