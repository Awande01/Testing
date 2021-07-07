using Api.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service
{
   public  interface ITransaction
    {
        int? InsertTransactions(MTransaction objtran);
        List<GetAllAccountsTransactions_Result> GetAllAccountsTransaction(string accountnumber);
    }
}
