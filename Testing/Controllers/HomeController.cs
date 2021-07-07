using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult _Menu()
        {
            try
            {
                return PartialView();
            }
            catch (Exception ex)
            {

                return PartialView();
            }
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}