using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vote_with_your_wallet.Models
{
    public class HomeViewModel
    {
        public NewCauseViewModel NewCauseViewModel { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }

        public LoginViewModel LoginViewModel { get; set; }

        public CausesViewModel CausesViewModel { get; set; }

        public HomeViewModel()
        {
            NewCauseViewModel = new NewCauseViewModel();
            RegisterViewModel = new RegisterViewModel();
            LoginViewModel = new LoginViewModel();
            CausesViewModel = new CausesViewModel();
        }
    }
}