using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Service
{
    public class PersonApiFilter
    {
        public int personcode { get; set; }
    }
    public class ApiSavePerosnFilter : PersonApiFilter
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string id_Number { get; set; }
    }
    public class ApiGetAccountTransactionFilter : PersonApiFilter
    {
        public string accountnumber { get; set; }
    }
    public class ApiGetPerosnFilter : PersonApiFilter
    {
        public string surname { get; set; }
        public string id_Number { get; set; }
    }
}