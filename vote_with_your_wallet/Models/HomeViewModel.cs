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
            this.CauseViewModel = new CauseViewModel();
            this.RegisterViewModel = new RegisterViewModel();
            this.LoginViewModel = new LoginViewModel();
        }
    }
}