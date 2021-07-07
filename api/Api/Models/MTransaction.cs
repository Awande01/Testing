using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class MTransaction
    {
        public decimal amount { get; set; }
        public string description { get; set; }
        public DateTime transactionDate { get; set; }
        public int accountCode { get; set; }
        public int transactionCode { get; set; }
    }
}