using CoreBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransacctionInMemoryRepository : ITransacctionRepository
    {
        private List<Transaction> transacctions;

        public TransacctionInMemoryRepository()
        {
            transacctions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
                return transacctions;
            else
                return transacctions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return transacctions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return transacctions.Where(x => x.TimeStamp.Date == date.Date &&  string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
            
        }

        public void Save(string cashierName, int productId, string productName, double? price, int beforeQty ,int soldQty)
        {
            int transacctionId = 1;
            if (transacctions != null && transacctions.Count > 0)
            {
                int maxId = transacctions.Max(x => x.TransacctionId);
                transacctionId = maxId + 1;
            }

            transacctions.Add(new Transaction
            {
                ProductId = productId,
                Price = price.Value,
                SoldQty = soldQty,
                 BeforeQty = beforeQty,
                  ProductName = productName,
                TimeStamp = DateTime.Now,
                TransacctionId = transacctionId,
                CashierName = cashierName,
            });
        }
    }
}
