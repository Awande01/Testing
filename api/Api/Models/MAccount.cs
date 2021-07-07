using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class MAccount
    {
        public int person_code { get; set; }
        public string accountnumber { get; set; }
        public int outstanding_balance { get; set; }
        public int accountCode { get; set; }
    }

}