using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL.Repository.Filter
{
    public class PersonApiFilter
    {
        public int personcode { get; set; }
    }
    public class ApiSavePerosnFilter 
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string id_Number { get; set; }
    }
    public class ApiGetAccountsFilter 
    {
        public string accountnumber { get; set; }
    }


}