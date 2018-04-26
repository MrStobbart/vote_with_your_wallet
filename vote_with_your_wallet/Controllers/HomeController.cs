﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vote_with_your_wallet.Controllers
{
    public class HomeController : Controller
    {
        public bool UserAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

        public ActionResult Index()
        {
            ViewBag.UserAuthenticated = UserAuthenticated;

            return View();
        }

    }
}