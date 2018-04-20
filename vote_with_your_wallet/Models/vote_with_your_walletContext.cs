using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace vote_with_your_wallet.Models
{
    public class vote_with_your_walletContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public vote_with_your_walletContext() : base("name=vote_with_your_walletContext")
        {
        }

        public System.Data.Entity.DbSet<vote_with_your_wallet.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<vote_with_your_wallet.Models.Cause> Causes { get; set; }
    }
}
