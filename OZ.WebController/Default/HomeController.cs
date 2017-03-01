using OZ.WebController.SharedBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OZ.WebController.Default
{
    public class HomeController : FrontendControllerBase
    {
        public ViewResult Index()
        {
            return View();
        }
        public string Test()
        {
            return "Test";
        }
    }
}
