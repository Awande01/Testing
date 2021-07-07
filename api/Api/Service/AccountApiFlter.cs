using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Service
{
    public class AccountApiFlter
    {
        public int transactionCode { get; set; }
        public int accountCode { get; set; }
    }
    public class ApiSaveAccountFilter : AccountApiFlter
    {
        public int person_code { get; set; }
        public string accountnumber { get; set; }
        public int outstanding_balance { get; set; }
    }
    public class ApiGetAccouontsFilter : AccountApiFlter
    {
        public string account_numbe { get; set; }
        public string id_Number { get; set; }
    }
    public class ApiGeAccountFilter : AccountApiFlter
    {
        public int person_code { get; set; }
    }
    public class ApiSaveTransactionFilter : AccountApiFlter
    {
        public decimal amount { get; set; }
        public string description { get; set; }
        public DateTime transactionDate { get; set; }
        public int accountcode { get; set; }

    }
}