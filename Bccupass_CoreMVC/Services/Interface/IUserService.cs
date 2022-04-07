using Bccupass_CoreMVC.Models.DTO.User;
using System.Collections.Generic;
using System.Linq;

namespace Bccupass_CoreMVC.Services
{
    public interface IUserService
    {
        public IQueryable<UserTicketDto.OrderData> GetOrderListOfUser(int userId);
        //public UserTicketDto GetTicket(int userId);
    }
}
