using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL.Repository
{
    public class Constants
    {
        public static class Config
        {
            public static string TestApiUrl => (System.Configuration.ConfigurationManager.AppSettings["TestApiUrl"]);

        }
    }

}