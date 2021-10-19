using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.Services;
namespace Technovert.BankApp.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***********Welcome*************");
            int x = 0;
            while (x != 1)
            {
                UserChoices userChoice = (UserChoices)Enum.Parse(typeof(UserChoices), Console.ReadLine());
                switch (userChoice)
                {
                    case UserChoices.CreateBank:
                        {
                            BankMessages.UserOutput("Enter Bank Name ");
                            string BankName = BankMessages.GetStringInput();
                            BankMessages.UserOutput("Enter Ifsc Code");
                            string ifscCode = BankMessages.GetStringInput();
                            BankServices.AddBank(BankName,ifscCode);
                            break;
                        }
                    case UserChoices.CreateAccount:
                        {
                            BankMessages.UserOutput("Enter Bank Id ");
                            string bankId = BankMessages.GetStringInput();
                            Bank b = BankDatastore.BankLists.Single(m => m.BankId == bankId);
                            BankMessages.UserOutput("Enter Account Holder Name");
                            string accountHolderName = BankMessages.GetStringInput();
                            Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine());
                            AccountServices.AddAccount(accountHolderName,bankId,gender);
                            break;
                        }
                    case UserChoices.Deposit:
                        {
                            AccountServices.Deposit();
                            break;
                        }
                    case UserChoices.Withdraw:
                        {
                            AccountServices.Withdraw();
                            break;
                        }
                    case UserChoices.Transfer:
                        {
                            AccountServices.Transfer();
                            break;
                        }
                    case UserChoices.Transactions:
                        {
                            BankMessages.UserOutput("Enter AccountId");
                            string actId = BankMessages.GetStringInput();
                            BankMessages.UserOutput("Enter pin");
                            string pin = BankMessages.GetStringInput();
                            TransactionServices.PrintTransaction(actId,pin);
                            break;
                        }

                }
            }
        }
    }
}
