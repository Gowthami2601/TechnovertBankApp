using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Exceptions;
namespace Technovert.BankApp.Services
{
    public class BankServices
    {
        public static void AddBank(string BankName, string IfscCode)
        {
            if (ValidateBankName(BankName, IfscCode))
            {
                throw new AlreadyExistedBank();
            }
            else
            {
                Bank b = new Bank
                {
                    BankName = BankName,
                    IfscCode = IfscCode,
                    BankId = GenerateIdServices.GenerateBankId(BankName, IfscCode),
                    CreatedOn = DateTime.Now,
                    AccountsList = new List<Account>()
                };
                BankMessages.UserOutput("Bank " +b.BankId + " is created :)");
            }
        }
        public static bool ValidateBankName(string BankName,string IfscCode)
        {
            if(BankDatastore.BankLists.Any(m => m.BankName == BankName))
            {
                return false;
            }
            else
            {
                if (BankDatastore.BankLists.Any(m => m.IfscCode == IfscCode))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
