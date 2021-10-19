using System;
using System.Collections.Generic;
namespace Technovert.BankApp.Models
{
    public class Bank
    {
        public string BankName { get; set; }
        public string BankId { get; set; }
        public string IfscCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Account> AccountsList { get; set; }
    }
}
