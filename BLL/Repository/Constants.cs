using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.Repository
{
    public class Constants
    {
        public static class Config
        {
            public static string BetApiUrl => (System.Configuration.ConfigurationManager.AppSettings["TestApiUrl"]);

        }
    }

}