using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models.Enums;
namespace Technovert.BankApp.Models
{
    public class Account
    {
        public string AccountId { get; set; }
        public string AccountHolderName { get; set; }
        public string pin { get; set; }
        public double Balance { get; set; }

        public string BankId { get; set; }
        public List<Transaction> TransactionList { get; set; }
        public Gender Gender { get; set; }
    }
}
