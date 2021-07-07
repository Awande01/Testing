using Api.Models;
using Api.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccount _iaccount;
        private readonly ITransaction _itransactiont;
        public AccountController(IAccount iaccount, ITransaction itransactiont)
        {
            _iaccount = iaccount;
            _itransactiont = itransactiont;
        }

        [HttpGet]
        public ResponseGetAllPersonAccount GetPersonAccount(ApiGetAccouontsFilter objpa)
        {
            var response = new ResponseGetAllPersonAccount
            {
                ResponseMessage = "No data found"
            };
            var objlist = _iaccount.GetAllPersonAccounts(objpa.account_numbe,objpa.id_Number);
            if(objlist.Count> 0)
            {
                response.listData.AddRange(objlist);
            }
            return response;
        }

        [HttpPost]
        public ResponseDetails SaveAccount(ApiSaveAccountFilter objacc)
        {
            var response = new ResponseDetails
            {
                ResponseMessage = "Account not saved"
            };
            var objnewAcc = new MAccount
            {
                accountnumber = objacc.accountnumber,
                outstanding_balance = objacc.outstanding_balance,
                person_code = objacc.person_code
            };
            var objpersonacc = _iaccount.InsertAccount(objnewAcc);
            if (objpersonacc > 0)
            {
                response.ResponseMessage = "Account saved successfully";
                response.RespondeType = objpersonacc;

            }
            return response;
        }

        [HttpGet]
        public ResponseGetAllAccountTransaction GetTransactions(ApiGetAccountTransactionFilter objacc)
        {
            var response = new ResponseGetAllAccountTransaction
            {
                ResponseMessage = "No data found"
            };
            var list =  _itransactiont.GetAllAccountsTransaction(objacc.accountnumber);
            if(list.Count > 0)
            {
                response.listData.AddRange(list);
            }
            return response;
        }

        [HttpPost]
        public ResponseDetails SaveTransaction(ApiSaveTransactionFilter objtrans)
        {
            var response = new ResponseDetails
            {
                ResponseMessage = "No data found"
            };
            var objnewTrans = new MTransaction
            {
                amount = objtrans.amount,
                accountCode = objtrans.accountCode,
                description = objtrans.description,
                transactionDate = objtrans.transactionDate
            };
            var obj = _itransactiont.InsertTransactions(objnewTrans);
            if (obj > 0)
            {
                response.ResponseMessage = "Transaction saved successfully";
                response.RespondeType = obj;
            }
            return response;
        }
    }
}
