using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task Execute(int productId)
        {
            await productRepository.DeleteProduct(productId);
        }
    }
}
