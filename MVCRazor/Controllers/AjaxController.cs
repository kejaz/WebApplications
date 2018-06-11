using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCRazor.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public string GetData()
        {
            try
            {
                int zero = 0;
                int result = 100 / zero;
                Thread.Sleep(3000);
                return "This is test data back from Ajax Controller";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}