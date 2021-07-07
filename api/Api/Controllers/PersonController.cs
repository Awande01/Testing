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
    public class PersonController : ApiController
    {
        private readonly IPerson _iperson;

        public PersonController(IPerson iperson)
        {
            _iperson = iperson;
        }

        [HttpGet]
        public ResponseGetAll GetAllPersons(ApiSavePerosnFilter objp)
        {
            var response = new ResponseGetAll
            {
                ResponseMessage = "Person not saved"
            };
            var objnewP = new MPerson
            {
                surname = objp.surname,
                id_Number = objp.id_Number,
                name = objp.name,
            };
            var obj = _iperson.GetAll(objnewP);
            if(obj.Count > 0)
            {
                response.listData.AddRange(obj);
            }
            return response;
        }

        [HttpPost]
        public ResponseDetails SavePerson(ApiSavePerosnFilter objp)
        {
            var response = new ResponseDetails
            {
                RespondeType = -1,
                ResponseMessage = "Record not saved"
            };
            var objnewP = new MPerson
            {
                name = objp.name,
                surname = objp.surname,
                id_Number = objp.id_Number,
            };
            var obj =  _iperson.AddPerson(objnewP);
            if (obj > 0)
            {
                response.RespondeType = obj;
                response.ResponseMessage = "Save successfully";
            }
            return response;
        }

        [HttpDelete]
        public ResponseDetails DeletePerson(int personCode)
        {
            var response = new ResponseDetails
            {
                RespondeType = -1,
                ResponseMessage = "Person can not be deleted"
            };

            var obj =  _iperson.Delete(personCode);
            if(obj == 1)
            {
                response.RespondeType = 1;
                response.ResponseMessage = "Person deleted successfully";
            }
            return response;
        }
    }
}
