using BLL;
using BLL.Repository.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Testing.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// add new perosn or update exixting person
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult InsertPerson(string firstName, string surname, string idNumber, int? code = null)
        {
            try
            {
                var newobj = new ApiSavePerosnFilter
                {
                    id_Number = idNumber,
                    name = firstName,
                    surname = surname
                };
                var objperson = Directory.InsertPerson(newobj);
                return Json(objperson, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// get  record from person table
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult GetPersonRecords(string surname, string idNumber)
        {
            try
            {
                var newobj = new ApiGetPerosnFilter
                {
                    id_Number = idNumber,
                    surname = surname
                };
                var objperson = Directory.GetPersonRecords(newobj);
                var resultList = new
                {
                    List = (from n in objperson
                            orderby n.code descending
                            select new
                            {
                                n.code,
                                n.id_number,
                                n.name,
                                n.surname
                            })
                };
                return Json(resultList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// /delete person
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult DeletePerson(int code)
        {
            try
            {
                var objdeleteperson = Directory.DeletePersons(code);
                return Json(objdeleteperson, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// add person accounts
        /// </summary>
        /// <param name="accountnumber"></param>
        /// <param name="balance"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult InsertAccount(string accountnumber, decimal balance, int code, int accountcode)
        {
            try
            {
                var newobj = new ApiSaveAccountFilter
                {
                    accountnumber = accountnumber,
                    outstanding_balance = balance,
                    person_code = code
                };
                var objperson = Directory.InsertAccount(newobj);
                return Json(objperson, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// get person account list
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="rowPerPage"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        public JsonResult GetPersonAccountRecords(string accountnumber, string idNumber)
        {
            try
            {
                var newobj = new ApiGetAccouontsFilter
                {
                    account_numbe = accountnumber,
                    id_Number= idNumber
                };
                var objList = Directory.GetAllPersonAccounts(newobj);               
                var resultList = new
                {
                    List = (from n in datalist
                            orderby n.code descending
                            select new
                            {
                                n.code,
                                n.id_number,
                                n.name,
                                n.surname,
                                n.account_number,
                                n.outstanding_balance
                                ,
                                n.AccountCode
                            })
                };
                return Json(resultList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GeAccountTransactionRecords(string accountNumber)
        {
            try
            {
                var newobj = new ApiGetAccountTransactionFilter
                {
                    accountnumber = accountNumber,
                };
                var objtransactionList = Directory.GetAllAccountsTransaction(newobj);
                return Json(objtransactionList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// add acount transaction
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <param name="idNumber"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult InsertTransaction(string description, decimal amount, int accountcode, DateTime transactiondate, int? transactioncode)
        {
            try
            {
                var newobj = new ApiSaveTransactionFilter
                {
                    amount = amount,
                    accountcode = accountcode,
                    description = description,
                    transactionDate = transactiondate
                };
                var objtransaction = Directory.InsertTransactions(newobj);
                return Json(objtransaction, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}