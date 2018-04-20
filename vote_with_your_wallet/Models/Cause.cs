using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vote_with_your_wallet.Models
{
    public class Cause
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public List<User> Supporters { get; set; }

        public void SupportCause(User user)
        {
            Supporters.Add(user);
        }
    }
}