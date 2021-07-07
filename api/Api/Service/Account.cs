using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Api.Models;
namespace Api.Service
{
    public class Account : IAccount, ITransaction
    {
        private readonly TestingEntities _context;
        public Account(TestingEntities context)
        {
            _context = context;
        }
        public  int? InsertAccount(MAccount objacc)
        {
                return _context.InsertAccount(objacc.accountnumber, objacc.outstanding_balance, objacc.accountCode, objacc.accountCode).FirstOrDefault();
        }
        public int? InsertTransactions(MTransaction objtran)
        {
            return _context.InsertTransactions(objtran.accountCode, objtran.amount, objtran.transactionDate, objtran.description, objtran.transactionCode).FirstOrDefault();
        }
        public List<GetAllAccountsTransactions_Result> GetAllAccountsTransaction(string accountnumber)
        {
            return _context.GetAllAccountsTransactions(accountnumber).ToList();
        }
        public  List<GetAllPersonAccounts_Result> GetAllPersonAccounts(string account_numbe, string idnumber)
        {
               return _context.GetAllPersonAccounts(idnumber,account_numbe).ToList();
        }

    }
}