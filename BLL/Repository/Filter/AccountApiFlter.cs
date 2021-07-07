using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Repository.Filter
{
    public class AccountApiFlter
    {
        public int transactionCode { get; set; }
        public int accountCode { get; set; }
    }
    public class ApiSaveAccountFilter 
    {
        public int person_code { get; set; }
        public string accountnumber { get; set; }
        public decimal outstanding_balance { get; set; }
    }
    public class ApiGetAccouontsFilter
    {
        public string account_numbe { get; set; }
        public string id_Number { get; set; }
    }
    public class ApiGeAccountFilter
    {
        public int person_code { get; set; }
    }
    public class ApiSaveTransactionFilter 
    {
        public decimal amount { get; set; }
        public string description { get; set; }
        public DateTime transactionDate { get; set; }
        public int accountcode { get; set; }

    }
    public class ApiGetAccountTransactionFilter
    {
        public string accountnumber { get; set; }
    }
}