using System.Configuration;
using System.Threading.Tasks;
using RestSharp;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Linq;
namespace BL.Repository
{
    public static class Rest
    {
        private static bool _ranOnce;
        static MemoryCache memCache = MemoryCache.Default;
        private static readonly RestClient client = new RestClient();

        private static void InitializeOnce(string uri)
        {
            if (_ranOnce && client.BaseUrl.AbsoluteUri.Contains(uri)) return;
            client.BaseUrl = new Uri(uri);
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddHandler("application/json", JsonSerializer.Default);
            client.AddHandler("text/json", JsonSerializer.Default);
            client.AddHandler("text/x-json", JsonSerializer.Default);
            client.AddHandler("text/javascript", JsonSerializer.Default);
            client.AddHandler("*+json", JsonSerializer.Default);
            _ranOnce = true;
        }
        public static async Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            InitializeOnce(Constants.Config.TestApiUrl);

            //ignore bad certificates
            System.Net.ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;

            return await client.ExecuteTaskAsync<T>(request);
        }
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }


    }

}
