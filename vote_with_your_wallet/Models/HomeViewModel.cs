using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vote_with_your_wallet.Models
{
    public class HomeViewModel
    {
        public CauseViewModel CauseViewModel { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }

        public LoginViewModel LoginViewModel { get; set; }

        public HomeViewModel()
        {
            CauseViewModel = new CauseViewModel();
            RegisterViewModel = new RegisterViewModel();
            LoginViewModel = new LoginViewModel();
        }
    }
}