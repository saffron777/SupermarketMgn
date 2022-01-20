using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IRecordTransacctionUseCase recordTransacctionUseCase;

        public SellProductUseCase(IProductRepository productRepository , IRecordTransacctionUseCase recordTransacctionUseCase)
        {
            this.productRepository = productRepository;
            this.recordTransacctionUseCase = recordTransacctionUseCase;
        }
        public void Execute(string cashierName, int productId, int qtyToSell)
        {
            var product = productRepository.GetProductById(productId);

            if (product == null) return;

            recordTransacctionUseCase.Execute(cashierName, productId, qtyToSell);
            product.Quantity -= qtyToSell;
            productRepository.UpdateProduct(product);
            
        }
    }
}
