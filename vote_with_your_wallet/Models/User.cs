using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vote_with_your_wallet.Enums;

namespace vote_with_your_wallet.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public AccountType accountType { get; set; }
    }
}