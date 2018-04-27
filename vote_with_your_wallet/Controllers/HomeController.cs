using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace vote_with_your_wallet.Controllers
{
    public class HomeController : Controller
    {

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


            return View();
        }

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


    }
}