using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vote_with_your_wallet.Entities;

namespace vote_with_your_wallet.Models
{
    public class CausesViewModel
    {
        public List<CauseViewModel> CauseViewModels { get; set; }

        public CausesViewModel()
        {
            CauseViewModels = new List<CauseViewModel>();
        }

        public CausesViewModel(List<Cause> causes)
        {
            CauseViewModels = new List<CauseViewModel>();
            foreach (var cause in causes)
            {
                CauseViewModel causeViewModel= new CauseViewModel(cause);
                CauseViewModels.Add(causeViewModel);
            }
        }
    }
}