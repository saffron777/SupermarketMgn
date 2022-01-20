using CoreBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTodayTransactionsUseCase : IGetTodayTransactionsUseCase
    {
        private readonly ITransacctionRepository transacctionRepository;

        public GetTodayTransactionsUseCase(ITransacctionRepository transacctionRepository)
        {
            this.transacctionRepository = transacctionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return transacctionRepository.GetByDay(cashierName, DateTime.Now);
        }
    }
}
