using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technovert.BankApp.Services
{
    public class GenerateIdServices
    {
        public static string GenerateBankId(string BankName, string IfscCode)
        {
            string BankId = BankName.Substring(0, 3) + DateTime.Now.ToString();
            return BankId;
        }
        public static string GenerateAccountId(string accountName)
        {
            string accountId = accountName.Substring(0, 3) + DateTime.Now.ToString();
            return accountId;
        }
        public static string GenerateTransactionId(string accountId,string bankId)
        {
            string Transactionid = "TXN" + accountId + bankId + DateTime.Now.ToString();
            return Transactionid;
        }
    }

}
