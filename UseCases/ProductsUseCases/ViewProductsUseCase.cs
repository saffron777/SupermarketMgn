using CoreBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductsUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> Execute()
        {
            return productRepository.GetProducts();
        }
    }
}
