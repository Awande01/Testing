﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TestingEntities : DbContext
    {
        public TestingEntities()
            : base("name=TestingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<Nullable<int>> DeletePerson(Nullable<int> code)
        {
            var codeParameter = code.HasValue ?
                new ObjectParameter("code", code) :
                new ObjectParameter("code", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeletePerson", codeParameter);
        }
    
        public virtual ObjectResult<GetAllAccountsTransactions_Result> GetAllAccountsTransactions(string account_number)
        {
            var account_numberParameter = account_number != null ?
                new ObjectParameter("account_number", account_number) :
                new ObjectParameter("account_number", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllAccountsTransactions_Result>("GetAllAccountsTransactions", account_numberParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertPerson(string name, string surname, string id_number, Nullable<int> code)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var surnameParameter = surname != null ?
                new ObjectParameter("surname", surname) :
                new ObjectParameter("surname", typeof(string));
    
            var id_numberParameter = id_number != null ?
                new ObjectParameter("id_number", id_number) :
                new ObjectParameter("id_number", typeof(string));
    
            var codeParameter = code.HasValue ?
                new ObjectParameter("code", code) :
                new ObjectParameter("code", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertPerson", nameParameter, surnameParameter, id_numberParameter, codeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertTransactions(Nullable<int> account_code, Nullable<decimal> amount, Nullable<System.DateTime> transaction_date, string description, Nullable<int> transaction_code)
        {
            var account_codeParameter = account_code.HasValue ?
                new ObjectParameter("account_code", account_code) :
                new ObjectParameter("account_code", typeof(int));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(decimal));
    
            var transaction_dateParameter = transaction_date.HasValue ?
                new ObjectParameter("transaction_date", transaction_date) :
                new ObjectParameter("transaction_date", typeof(System.DateTime));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var transaction_codeParameter = transaction_code.HasValue ?
                new ObjectParameter("transaction_code", transaction_code) :
                new ObjectParameter("transaction_code", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertTransactions", account_codeParameter, amountParameter, transaction_dateParameter, descriptionParameter, transaction_codeParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertAccount(string account_number, Nullable<decimal> outstanding_balance, Nullable<int> code, Nullable<int> accountcode)
        {
            var account_numberParameter = account_number != null ?
                new ObjectParameter("account_number", account_number) :
                new ObjectParameter("account_number", typeof(string));
    
            var outstanding_balanceParameter = outstanding_balance.HasValue ?
                new ObjectParameter("outstanding_balance", outstanding_balance) :
                new ObjectParameter("outstanding_balance", typeof(decimal));
    
            var codeParameter = code.HasValue ?
                new ObjectParameter("code", code) :
                new ObjectParameter("code", typeof(int));
    
            var accountcodeParameter = accountcode.HasValue ?
                new ObjectParameter("accountcode", accountcode) :
                new ObjectParameter("accountcode", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertAccount", account_numberParameter, outstanding_balanceParameter, codeParameter, accountcodeParameter);
        }
    
        public virtual ObjectResult<GetAllPersons_Result> GetAllPersons(string idnumber, string surname)
        {
            var idnumberParameter = idnumber != null ?
                new ObjectParameter("idnumber", idnumber) :
                new ObjectParameter("idnumber", typeof(string));
    
            var surnameParameter = surname != null ?
                new ObjectParameter("surname", surname) :
                new ObjectParameter("surname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllPersons_Result>("GetAllPersons", idnumberParameter, surnameParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> GetGetAllPersonsPagination(string idnumber, string surname)
        {
            var idnumberParameter = idnumber != null ?
                new ObjectParameter("idnumber", idnumber) :
                new ObjectParameter("idnumber", typeof(string));
    
            var surnameParameter = surname != null ?
                new ObjectParameter("surname", surname) :
                new ObjectParameter("surname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("GetGetAllPersonsPagination", idnumberParameter, surnameParameter);
        }
    
        public virtual ObjectResult<GetAllPersonAccounts_Result> GetAllPersonAccounts(string idnumber, string account_numbe)
        {
            var idnumberParameter = idnumber != null ?
                new ObjectParameter("idnumber", idnumber) :
                new ObjectParameter("idnumber", typeof(string));
    
            var account_numbeParameter = account_numbe != null ?
                new ObjectParameter("account_numbe", account_numbe) :
                new ObjectParameter("account_numbe", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllPersonAccounts_Result>("GetAllPersonAccounts", idnumberParameter, account_numbeParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> GetAllPersonAccountsPagination(string idnumber, string account_numbe)
        {
            var idnumberParameter = idnumber != null ?
                new ObjectParameter("idnumber", idnumber) :
                new ObjectParameter("idnumber", typeof(string));
    
            var account_numbeParameter = account_numbe != null ?
                new ObjectParameter("account_numbe", account_numbe) :
                new ObjectParameter("account_numbe", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("GetAllPersonAccountsPagination", idnumberParameter, account_numbeParameter);
        }
    }
}
