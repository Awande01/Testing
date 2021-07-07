using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Repository.Response;
using RestSharp;
using BLL.Repository;
using System.Net;
using BLL.Repository.Filter;

namespace BLL
{
    public class Directory
    {
        public static async Task<ResponseDetails> InsertPerson(ApiSavePerosnFilter obp)
        {
            var req = new RestRequest("/Person/Save", Method.POST);
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
        public static async Task<ResponseGetAll> GetPersonRecords(ApiGetPerosnFilter obp)
        {
            var req = new RestRequest("/Person/GetAllPersons", Method.GET);
            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = JsonSerializer.Default;
            req.AddJsonBody(obp);
            req.AddBody(obp);
            var response = await Rest.ExecuteAsync<ResponseGetAll>(req);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }

        public static async Task<ResponseDetails> DeletePersons(int personCode)
        {
            var req = new RestRequest("/Person/DeletePerson", Method.GET);
            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = JsonSerializer.Default;
            req.AddJsonBody(personCode);
            req.AddBody(personCode);
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

        public static async Task<ResponseDetails> InsertAccount(ApiSaveAccountFilter objacc)
        {
            var req = new RestRequest("/Account/SaveAccount", Method.GET);
            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = JsonSerializer.Default;
            req.AddJsonBody(objacc);
            req.AddBody(objacc);
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
        public static async Task<ResponseDetails> GetAllPersonAccounts(ApiGetAccouontsFilter objacc)
        {
            var req = new RestRequest("/Account/GetPersonAccount", Method.GET);
            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = JsonSerializer.Default;
            req.AddJsonBody(objacc);
            req.AddBody(objacc);
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
        public static async Task<ResponseGetAllAccountTransaction> GetAllAccountsTransaction(ApiGetAccountTransactionFilter objacc)
        {
            var req = new RestRequest("/Account/GetTransactions", Method.GET);
            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = JsonSerializer.Default;
            req.AddJsonBody(objacc);
            req.AddBody(objacc);
            var response = await Rest.ExecuteAsync<ResponseGetAllAccountTransaction>(req);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception(response.StatusDescription, new Exception(response.Content));
                }
            }
            return response.Data;
        }
        public static async Task<ResponseDetails> InsertTransactions(ApiSaveTransactionFilter objacc)
        {
            var req = new RestRequest("/Account/SaveTransaction", Method.GET);
            req.RequestFormat = DataFormat.Json;
            req.JsonSerializer = JsonSerializer.Default;
            req.AddJsonBody(objacc);
            req.AddBody(objacc);
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
