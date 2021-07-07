using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Repository.Response
{
    public class ApiResponse
    {
        public string ResponseMessage { get; set; }
    }

    public class ResponseDetails : ApiResponse
    {
        public int? RespondeType { get; set; }
    }

    public class ResponseGetAll :ApiResponse
    {
       public List<GetAllPersons_Result> listData { get; set; }
    }
    public class ResponseGetAllPersonAccount : ApiResponse
    {
        public List<GetAllPersonAccounts_Result> listData { get; set; }
    }
    public class ResponseGetAllAccountTransaction : ApiResponse
    {
        public List<GetAllAccountsTransactions_Result> listData { get; set; }
    }
}