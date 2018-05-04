using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vote_with_your_wallet.Entities
{
    public class Cause
    {
        public Cause() {
            Supporters = new HashSet<ApplicationUser>();
        }

        public Cause(int id, string title, string causeTarget, string description, HashSet<ApplicationUser> supporters)
        {
            Id = id;
            Title = title;
            CauseTarget = causeTarget;
            Description = description;
            Supporters = supporters;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public string CauseTarget { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> Supporters { get; set; }


    }
}