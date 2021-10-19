using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models.Enums;
namespace Technovert.BankApp.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public double Balance { get; set; }
        public string FromAccountId{ get; set; }
        public string ToAccountId { get; set; }
        public TransactionTypes TransactionType { get; set; }
    }
}
