using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Controllers
{
    public class CustomModelBindingController : Controller
    {
        //
        // GET: /CustomizeModelBinding/

        public ActionResult CustomValueProviderAction(DateTime currentTime)
        {
            return View((object)currentTime.ToLongTimeString());
        }

    }
}
