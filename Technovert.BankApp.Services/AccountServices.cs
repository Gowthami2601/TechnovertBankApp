using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;
using Technovert.BankApp.Models.Exceptions;
namespace Technovert.BankApp.Services
{
    public class AccountServices
    {
        public static void AddAccount(string name, string bankId, Gender gender)
        {
            Bank b = BankDatastore.BankLists.Single(m => m.BankId == bankId);
            Account acc = new Account
            {
                AccountHolderName = name,
                Gender = gender,
                AccountId = GenerateIdServices.GenerateAccountId(name),
                BankId = bankId,
                Balance = 0,
                TransactionList = new List<Transaction>()
            };
            b.AccountsList.Add(acc);
        }
        public static void Deposit()
        {
            BankMessages.UserOutput("Enter your bank Id");
            string bankId = BankMessages.GetStringInput();
            Bank b = BankDatastore.BankLists.Single(m => m.BankId == bankId);
            BankMessages.UserOutput("Enter your account number");
            string accountId = BankMessages.GetStringInput();
            Account a = b.AccountsList.Single(m => m.AccountId == accountId);
            if (b != null && a != null)
            {
                BankMessages.UserOutput("Enter your account number");
                string pin = BankMessages.GetStringInput();
                if (a.pin == pin)
                {
                    Console.WriteLine("Enter the amount");
                    int deposit = BankMessages.GetIntInput();
                    a.Balance += deposit;
                    BankMessages.UserOutput("Deposited succesfully.");
                    PrintCurrentBal(bankId, accountId, pin);
                    TransactionTypes tr = TransactionTypes.Credit;
                    TransactionServices.AddTransaction(accountId,accountId,bankId,bankId,tr,DateTime.Now);
                }
                else
                {
                    throw new InvalidPinException();
                }
            }
            else
            {
                throw new InvalidAccountException();
            }
        }
        public static void Withdraw()
        {
            BankMessages.UserOutput("Enter your bank Id");
            string bankId = BankMessages.GetStringInput();
            Bank b = BankDatastore.BankLists.Single(m => m.BankId == bankId);
            BankMessages.UserOutput("Enter your account number");
            string accountId = BankMessages.GetStringInput();
            Account a = b.AccountsList.Single(m => m.AccountId == accountId);
            if (b != null && a != null)
            {
                BankMessages.UserOutput("Enter your account number");
                string pin = BankMessages.GetStringInput();
                if (a.pin==pin)
                {
                    Console.WriteLine("Enter the amount");
                    int withdraw = BankMessages.GetIntInput();
                    if (withdraw <= a.Balance)
                    {
                        a.Balance-= withdraw;
                        BankMessages.UserOutput("Withdrawing completed succesfully.");
                        PrintCurrentBal(bankId,accountId, pin);
                        TransactionTypes tr = TransactionTypes.Credit;
                        TransactionServices.AddTransaction(accountId, accountId, bankId, bankId, tr, DateTime.Now);
                    }
                    else
                    {
                        throw new  InsufficientBalanceException();
                    }
                }
                else
                {
                    BankMessages.UserOutput("Invlaid Pin");
                }
            }
            else
            {
                Console.WriteLine("Invalid account id");
            }
        }
        public static void Transfer()
        {
            BankMessages.UserOutput("Enter your bank Id");
            string bankId = BankMessages.GetStringInput();
            Bank b = BankDatastore.BankLists.Single(m => m.BankId == bankId);
            BankMessages.UserOutput("Enter account number from which money should be transfered");
            string fromId = BankMessages.GetStringInput();
            Account a = b.AccountsList.Single(m => m.AccountId == fromId);
            if (a!=null && b!=null)
            {
                BankMessages.UserOutput("Enter your account number");
                string pin = BankMessages.GetStringInput();
                if (a.pin==pin)
                {
                    BankMessages.UserOutput("Enter your bank Id");
                    string bankId1 = BankMessages.GetStringInput();
                    Bank b1 = BankDatastore.BankLists.Single(m => m.BankId == bankId1);
                    BankMessages.UserOutput("Enter account number to which money should be transfered");
                    string toId = BankMessages.GetStringInput();
                    Account a1 = b.AccountsList.Single(m => m.AccountId ==toId);
                    if (b1!=null && a1!=null)
                    {
                        BankMessages.UserOutput("Entre amount");
                        int transferamt = BankMessages.GetIntInput();
                        if (transferamt <=a.Balance)
                        {
                            a.Balance-= transferamt;
                            a1.Balance+= transferamt;
                            DateTime dt = DateTime.Now;
                            TransactionTypes tr = TransactionTypes.Credit;
                            TransactionServices.AddTransaction(fromId, toId, bankId, bankId, tr,dt);
                            TransactionTypes tr1 = TransactionTypes.Credit;
                            TransactionServices.AddTransaction(fromId, toId, bankId, bankId, tr1,dt);
                        }
                        else
                        {
                            throw new InsufficientBalanceException();
                        }
                    }
                    else
                    {
                        throw new InvalidAccountException();
                    }
                }
                else
                {
                    throw new InvalidPinException();
                }
            }
            else
            {
                throw new InvalidAccountException();
            }
        }
        public static void PrintCurrentBal(string bankId,string accountId, string pin)
        {
            Bank b = BankDatastore.BankLists.Single(m => m.BankId == bankId);
            Account a = b.AccountsList.Single(m => m.AccountId == accountId);
            if (b!=null && a!=null)
            {
                if (a.pin==pin)
                {
                    BankMessages.UserOutput("Your Current Balance is " +a.Balance);
                }
            }
        }
    }
}
