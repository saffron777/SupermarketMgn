using CoreBussines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext db;

        public TransactionRepository(MarketContext db)
        {
            this.db = db;
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.transactions.ToList();
            else
                return db.transactions.Where(x => EF.Functions.Like(x.CashierName, $"%{cashierName}%")).ToList();
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.transactions.Where(x => x.TimeStamp.Date == date.Date).ToList();
            else
                return db.transactions.Where(x => x.TimeStamp.Date == date.Date && EF.Functions.Like(x.CashierName, $"%{cashierName}%" )).ToList();
        }

        public void Save(string cashierName, int productId, string productName, double? price, int beforeQty, int soldQty)
        {
            db.transactions.Add(new Transaction
            {
                ProductId = productId,
                Price = price.Value,
                SoldQty = soldQty,
                BeforeQty = beforeQty,
                ProductName = productName,
                TimeStamp = DateTime.Now,                
                CashierName = cashierName,
            });

            db.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(cashierName))
                return db.transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date).ToList();
            else
                return db.transactions.Where(x => (x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date) && EF.Functions.Like(x.CashierName, $"%{cashierName}%")).ToList();
        }
    }
}
