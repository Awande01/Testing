using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Repository.Response;
using RestSharp;
using BL.Repository;
using System.Net;
using BL.Repository.Filter;

namespace BL
{
    public class Directory
    {
        public static async Task<ResponseDetails> InsertPerson(ApiSavePerosnFilter obp)
        {
            var req = new RestRequest("Person/Save", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = JsonSerializer.Default;
            req.AddJsonBody(obp);
            req.AddBody(obp);
            var response = await Rest.ExecuteAsync<ResponseDetails>(req);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }


            return response.Data;
        }
        
    }
}
