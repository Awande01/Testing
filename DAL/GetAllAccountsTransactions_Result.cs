//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    
    public partial class GetAllAccountsTransactions_Result
    {
        public Nullable<int> transaction_code { get; set; }
        public int account_code { get; set; }
        public Nullable<long> Number { get; set; }
        public string account_number { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string id_number { get; set; }
        public string transaction_date { get; set; }
        public string capture_date { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string description { get; set; }
        public decimal outstanding_balance { get; set; }
    }
}
