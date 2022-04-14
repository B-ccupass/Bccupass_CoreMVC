using System;
using System.Collections.Generic;

namespace Bccupass_CoreMVC.Models.ViewModel.User
{
    public class UserTicketViewModel
    {
        public IEnumerable<ShowTicketViewModel> OrderList { get; set; }
        public int selcetByOrderState { get; set; }


    }

}

