using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Models;
using DAL;
namespace Api.Service
{
    public interface IPerson 
    {
        int? AddPerson(MPerson objperson);
        int? Delete(int personCode);
        List<GetAllPersons_Result> GetAll(MPerson objperson);

    }
}
