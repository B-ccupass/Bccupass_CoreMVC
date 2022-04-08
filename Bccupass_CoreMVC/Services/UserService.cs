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
            var orderList = _context.GetAll<OrderDetail>().Where(x => x.UserId == userId).Select(x => new UserTicketDto.OrderData() { OrderId = x.OrderDetailId }).ToList(); ;

            return orderList;
            //return orderList;
        }

        //public UserTicketDto GetTicket(int userId)
        //{
        //    return new UserTicketDto()
        //    {
        //        User = GetUserData(userId),
        //        Order = GetOrderDataByUserId(userId),
        //        TdOd = GetTdOdByUserId(userId),
        //        TicketDetail = GetTickeDetailByUserId(userId),
        //        Activity = GetActivityDataByUserId(userId),
        //    };
        //}

        //private UserTicketDto.UserData GetUserData(int userId)
        //{
        //    var user = _context.GetAll<User>().First(x => x.UserId == userId);
        //    return new UserTicketDto.UserData()
        //    {
        //        UserId = user.UserId
        //    };
        //}

        //private IEnumerable<UserTicketDto.OrderData> GetOrderDataByUserId(int userId)
        //{
        //    var res = _context.GetAll<OrderDetail>().Where(x => x.UserId == userId).Select(x => x.OrderDetailId);
        //    return _context.GetAll<OrderDetail>().Where(x => res.Any(y => y == x.OrderDetailId)).Select(x => new UserTicketDto.OrderData()
        //    {
        //        OrderId = x.OrderDetailId
        //    }) ;
        //}

        //private IEnumerable<UserTicketDto.TicketDatail> GetTickeDetailByUserId(int userId)
        //{
        //    var order = _context.GetAll<OrderDetail>().Where(x => x.UserId == userId).Select(x => x.OrderDetailId);
        //    var tdod = _context.GetAll<TicketDetailOrderDetail>().Where(x => order.Any(y => y == x.OrderDetailId)).Select(x => x.TicketDetailOrderDetailId);
        //    return _context.GetAll<TicketDatail>().Where(x => tdod.Any(y => y == x.TicketDatailId)).Select(x => new UserTicketDto.TicketDatail()
        //    {
        //        TicketId = x.TicketDatailId,
        //        TicketName = x.TicketName,
        //        Price = x.Price,
        //    });
        //}
        //private IEnumerable<UserTicketDto.TicketDetailOrderDetail> GetTdOdByUserId(int userId)
        //{
        //    var order = _context.GetAll<OrderDetail>().Where(x => x.UserId == userId).Select(x => x.OrderDetailId);
        //    return _context.GetAll<TicketDetailOrderDetail>().Where(x => order.Any(y => y == x.OrderDetailId)).Select(x => new UserTicketDto.TicketDetailOrderDetail()
        //    {
        //        TdOdId = x.TicketDetailOrderDetailId,
        //        BuyerName = x.BuyerName,
        //        BuyerEmail = x.BuyerEmail,
        //        BuyerPhone = x.BuyerPhone,
        //        BuyerCompanyName = x.BuyerConpanyName
        //    });
        //}

        //private IEnumerable<UserTicketDto.ActivityData> GetActivityDataByUserId(int userId)
        //{
        //    var order = _context.GetAll<OrderDetail>().Where(x => x.OrderDetailId == userId);
        //    return _context.GetAll<Activity>().Where(x => order.Any(y => y.ActivityId == x.ActivityId)).Select(x => new UserTicketDto.ActivityData()
        //    {
        //        ActId = x.ActivityId,
        //        ActName = x.Name,
        //        StartTime = x.StartTime,
        //        EndTime = x.EndTime,
        //    });
        //}


    }
}
