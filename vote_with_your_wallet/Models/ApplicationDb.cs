using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using vote_with_your_wallet.Entities;


namespace vote_with_your_wallet.Models
{
    public class ApplicationDb : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDb() : base("DefaultConnection", throwIfV1Schema: false){ }

        public DbSet<Cause> Causes { get; set; }
        
        // DbSet<ApplicationUser> is alread inherited from the IdentityDbContext

        public static ApplicationDb Create()
        {
            return new ApplicationDb();
        }
    }
}