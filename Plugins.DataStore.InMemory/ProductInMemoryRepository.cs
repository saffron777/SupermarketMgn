using CoreBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;

        public ProductInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product() { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Price = 2.99, Quantity = 300 },
                new Product() { ProductId = 2, CategoryId = 1, Name = "Ginger Ale", Price = 5.99, Quantity = 100 },
                new Product() { ProductId = 3, CategoryId = 1, Name = "Canada Dry", Price = 4.99, Quantity = 200 },
                new Product() { ProductId = 4, CategoryId = 2, Name = "Whole Wheat Bread", Price = 1.99, Quantity = 20 },
                new Product() { ProductId = 5, CategoryId = 2, Name = "White Bread", Price = 0.99, Quantity = 1000 },
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            var maxId = products.Count() > 0 ? products.Max(x => x.ProductId) : 0;
            product.ProductId = maxId + 1;            
            products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            var productUpdate = GetProductById( product.ProductId);

            if (productUpdate != null)
            {
                productUpdate.Name = product.Name;
                productUpdate.CategoryId = product.CategoryId;
                productUpdate.Price = product.Price;
                productUpdate.Quantity = product.Quantity;
            }
        }

        public Product GetProductById(int productId) => products?.FirstOrDefault(x => x.ProductId == productId);

        public async Task DeleteProduct(int productId)
        {
            products?.Remove(GetProductById(productId));
        }
    }
}
