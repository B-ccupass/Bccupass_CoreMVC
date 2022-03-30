using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Bccupass_CoreMVC.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _context;
        public TicketService(ITicketRepository context)
        {
            _context = context;
        }

        public CreateTicketDto GetTicket(int orderDetailId)
        {
            return new CreateTicketDto()
            {
                Order = GetOrderData(orderDetailId),
                TdOd = GetTdOdByOrderDetailId(orderDetailId),
                TicketDetail = GetTickeDetailByOrderDetailId(orderDetailId),
                Activity = GetActivityDataByOrderDetailId(orderDetailId),
                Organizer = GetOrganizerDataByOrderDetailId(orderDetailId),
            };
        }

        public int TicketCount(int orderDetailId)
        {
            var num = _context.GetAll<TicketDetailOrderDetail>().Where(x => x.OrderDetailId== orderDetailId).Count();

            return num;
        }


        //獲取訂單相關資料

        private CreateTicketDto.OrderData GetOrderData(int orderDetailId)
        {
            var order = _context.GetAll<OrderDetail>().First(x => x.OrderDetailId == orderDetailId);
            return new CreateTicketDto.OrderData()
            {
                OrderId = order.OrderDetailId,
            };
        }

        private IEnumerable<CreateTicketDto.TicketDatail> GetTickeDetailByOrderDetailId(int orderDetailId)
        {
            var res = _context.GetAll<TicketDetailOrderDetail>().Where(x => x.OrderDetailId == orderDetailId).Select(x => x.TicketDetailId);
            return _context.GetAll<TicketDatail>().Where(x => res.Any(y => y == x.TicketDatailId)).Select(x => new CreateTicketDto.TicketDatail()
            {
                TicketId = x.TicketDatailId,
                TicketName = x.TicketName
            });
        }
        private IEnumerable<CreateTicketDto.TicketDetailOrderDetail> GetTdOdByOrderDetailId(int orderDetailId)
        {
            return _context.GetAll<TicketDetailOrderDetail>().Where(x => x.TicketDetailOrderDetailId == orderDetailId).Select(x => new CreateTicketDto.TicketDetailOrderDetail()
            {
                TdOdId = x.TicketDetailOrderDetailId,
                BuyerName = x.BuyerName,
                BuyerEmail = x.BuyerEmail,
                BuyerPhone = x.BuyerPhone,
                BuyerCompanyName = x.BuyerConpanyName
            });


        }

        private CreateTicketDto.ActivityData GetActivityDataByOrderDetailId(int orderDetailId)
        {
            var order = _context.GetAll<OrderDetail>().First(x => x.OrderDetailId == orderDetailId);
            var act = _context.GetAll<Activity>().First((x => x.ActivityId == order.ActivityId));
            return new CreateTicketDto.ActivityData()
            {
                ActId = act.ActivityId,
                ActName = act.Name,
                StartTime = act.StartTime,
                EndTime = act.EndTime,
            };
        }

        private CreateTicketDto.OrganizerData GetOrganizerDataByOrderDetailId(int orderDetailId)
        {
            var order = _context.GetAll<OrderDetail>().First(x => x.OrderDetailId == orderDetailId);
            var act = _context.GetAll<Activity>().First((x => x.ActivityId == order.ActivityId));
            var org = _context.GetAll<Organizer>().First((x => x.OrganizerId == act.OrganizerId));
            return new CreateTicketDto.OrganizerData()
            {
                OrgId = org.OrganizerId,
                OrgName = org.Name,
                OrgEmail = org.Email,
                OrgPhone = org.Telphone
            };
        }

    }
}
