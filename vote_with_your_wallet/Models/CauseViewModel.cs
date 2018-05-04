using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vote_with_your_wallet.Entities;

namespace vote_with_your_wallet.Models
{
    public class CauseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Cause Title")]
        public string Title { get; set; }

        [Display(Name = "Choose a decision maker")]
        public string CauseTarget { get; set; }

        public string Description { get; set; }

        public List<ApplicationUser> Supporters { get; set; }

        public CauseViewModel(Cause cause) {
            Id = cause.Id;
            Title = cause.Title;
            Description = cause.Description;
            Supporters = cause.Supporters;
            CauseTarget = cause.CauseTarget;
        }

    }
}