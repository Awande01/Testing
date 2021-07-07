using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models;
using DAL;
using System.Threading.Tasks;

namespace Api.Service
{
    public class Person : IPerson
    {
        private readonly TestingEntities _context;
        public Person(TestingEntities context)
        {
            _context = context;
        }
        public int? AddPerson(MPerson objperson)
        {

            return _context.InsertPerson(objperson.name,objperson.surname,objperson.id_Number, objperson.personCode).FirstOrDefault();
                      
        }
        public  List<GetAllPersons_Result> GetAll(MPerson objperson)
        {

                return _context.GetAllPersons(objperson.id_Number, objperson.surname).ToList();
        }
        public  int? Delete(int personCode)
        {

                return _context.DeletePerson(personCode).FirstOrDefault();

        }
    }
}