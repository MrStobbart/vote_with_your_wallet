using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vote_with_your_wallet.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            bool UserAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            ViewBag.UserAuthenticated = UserAuthenticated;

            return View();
        }



    }
}