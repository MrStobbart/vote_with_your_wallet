using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vote_with_your_wallet.Models
{
    public class NavigationModel
    {
        public bool UserAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;


    }
}