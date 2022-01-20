using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class RecordTransacctionUseCase : IRecordTransacctionUseCase
    {
        private readonly ITransactionRepository transacctionRepository;
        private readonly IGetProductByIdUseCase getProductByIdUseCase;

        public RecordTransacctionUseCase(ITransactionRepository transacctionRepository, IGetProductByIdUseCase getProductByIdUseCase)
        {
            this.transacctionRepository = transacctionRepository;
            this.getProductByIdUseCase = getProductByIdUseCase;
        }
        public void Execute(string cashierName, int productId, int soldQty)
        {
            var product = getProductByIdUseCase.Execute(productId);
            transacctionRepository.Save(cashierName, productId, product.Name, product.Price, product.Quantity.Value, soldQty);
        }
    }
}
