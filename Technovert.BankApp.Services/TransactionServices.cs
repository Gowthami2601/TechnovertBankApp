using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technovert.BankApp.Models;
using Technovert.BankApp.Models.Enums;
namespace Technovert.BankApp.Services
{
    public class TransactionServices
    {
        public static string AddTransaction(string fromId, string toId, string fromBankId, string toBankId, TransactionTypes transactionType,DateTime dt)
        {
            Bank b = BankDatastore.BankLists.Single(m => m.BankId == fromBankId);
            Account a = b.AccountsList.Single(m => m.AccountId == fromId);
            Transaction tr = new Transaction {
                TransactionId = GenerateIdServices.GenerateTransactionId(fromId, fromBankId),
                TransactionDateTime =dt,
                Balance = a.Balance,
                FromAccountId = fromId,
                ToAccountId=toId,
                TransactionType=transactionType
            };
            a.TransactionList.Add(tr);
            return tr.TransactionId;
        }
        public static void PrintTransaction(string accountId,string bankId)
        {
            Bank b = BankDatastore.BankLists.Single(m => m.BankId == bankId);
            Account a = b.AccountsList.Single(m => m.AccountId == accountId);
            BankMessages.UserOutput("      TransactionId        |       At          |       From            |       To          |       Description          |      Balance     |");
            BankMessages.UserOutput("_____________________________________________________________");
            foreach (Transaction trns in a.TransactionList)
            {
                BankMessages.UserOutput(trns.TransactionId+ "            "+trns.TransactionDateTime+"           " + trns.FromAccountId + "           " + trns.ToAccountId + "               "+trns.TransactionType+"           "+ trns.Balance);
            }
            BankMessages.UserOutput("Thankyou :)");
        }
        public Transaction GetTransaction(string accountId,string bankId,string transactionId)
        {
            Bank b = BankDatastore.BankLists.Single(m => m.BankId == bankId);
            Account a = b.AccountsList.Single(m => m.AccountId == accountId);
            Transaction tr = a.TransactionList.Single(m => m.TransactionId == transactionId);
            return tr;
        }
    }
}
