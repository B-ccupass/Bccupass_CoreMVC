using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO.User;
using Bccupass_CoreMVC.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Bccupass_CoreMVC.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _context;
        public UserService(IUserRepository context )
        {
            _context = context;
        }
        public IEnumerable<UserTicketDto.OrderData> GetOrderListOfUser(int userId)
        {
            var orderList = _context.GetAll<OrderDetail>().Where(x => x.UserId == userId).Select(x => new UserTicketDto.OrderData() { OrderId = x.OrderDetailId }).ToList();


            return orderList;
        }
    }
}
