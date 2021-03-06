using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBussines
{
    public class Transaction
    {
        [Key]
        public int TransacctionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int BeforeQty { get; set; }
        public int SoldQty { get; set; }      
        public string CashierName { get; set; }
    }
}
