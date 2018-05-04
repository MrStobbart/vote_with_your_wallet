using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using vote_with_your_wallet.Entities;
using vote_with_your_wallet.Models;

namespace vote_with_your_wallet.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDb db = new ApplicationDb();
        private HomeViewModel model;

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public async Task<ActionResult> Index()
        {
            bool UserAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            ViewBag.UserAuthenticated = UserAuthenticated;
            ViewBag.IsAdmin = false;

            // Set ViewBag.IsAdmin to true when and admin is signed in
            if (UserAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = await UserManager.FindByNameAsync(userName);
                if(user.AccountType == Enums.AccountType.ADMINISTRATOR)
                {
                    ViewBag.IsAdmin = true;
                }
            }

            model = new HomeViewModel();
            List<Cause> causes = await db.Causes.ToListAsync();
            model.CausesViewModel = new CausesViewModel(causes);

            GetModelsFromTempDataIfAvailable();
            

            return View(model);
        }

        private void GetModelsFromTempDataIfAvailable()
        {
            if (TempData["RegisterViewModel"] != null)
            {
                model.RegisterViewModel = (RegisterViewModel)TempData["RegisterViewModel"];
            }

            if (TempData["LoginViewModel"] != null)
            {
                model.LoginViewModel = (LoginViewModel)TempData["LoginViewModel"];
            }

            if (TempData["NewCauseViewModel"] != null)
            {
                model.NewCauseViewModel = (NewCauseViewModel)TempData["NewCauseViewModel"];
            }

            if (TempData["CausesViewModel"] != null)
            {
                model.CausesViewModel = (CausesViewModel)TempData["CausesViewModel"];
            }
        }


    }
}