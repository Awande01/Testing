using Api.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service
{
    public interface IAccount
    {
        int? InsertAccount(MAccount objacc);
        List<GetAllPersonAccounts_Result> GetAllPersonAccounts(string account_numbe,string idnumber);
    }
}
