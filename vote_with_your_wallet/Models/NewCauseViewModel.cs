using System.ComponentModel.DataAnnotations;

namespace vote_with_your_wallet.Models
{
    public class NewCauseViewModel
    {

        [Required]
        [StringLength(100)]
        [Display(Name = "Cause Title")]
        public string Title { get; set; }

        [Display(Name = "Choose a decision maker")]
        public string CauseTarget { get; set; }

        [Required]
        public string Description { get; set; }
    }
}