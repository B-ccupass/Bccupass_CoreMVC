using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Services.Interface;
using Bccupass_CoreMVC.Models.DTO.Ticket;
using Bccupass_CoreMVC.Models.DBEntity;
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

        public IEnumerable<TicketPurchaseDto> GetTicketInfoAtPurchase(int activityId)
        {
            var target = _context.GetAll<TicketDatail>().Where(x => x.ActivityId == activityId);

            var result = target.Select(x => new TicketPurchaseDto() {
                TicketId = x.TicketDatailId,
                TicketName = x.TicketName,
                Price = x.Price,
                Quantity = x.Quantity,
                Description = x.Description,
                SellStartTime = x.SellStartTime,
                SellEndTime = x.SellEndTime,
                CheckStartTime = x.CheckStartTime,
                CheckEndTime = x.CheckEndTime,
                GroupName = x.TicketGroup
            });

            return result;
        }

        public void CreateOrderDetail(OrderDetailDto request)
        {
            var target = new OrderDetail()
            {
                ActivityId = request.ActivityId,
                UserId = request.UserId,
                OrderTime = request.OrderTime,
                OrderState = request.OrderState
            };

            _context.Create(target);
            _context.Save();
        }

        public void CreateTicketOrder(TicketOrderDto request)
        {
            var target = new TicketDetailOrderDetail()
            {
                OrderDetailId = request.OrderDetailId,
                TicketDetailId = request.TicketDtailId,
                CheckStatus = request.CheckStatus,
                UniPrice = request.Price,
                BuyerName = request.BuyerName,
                BuyerEmail = request.BuyerEmail,
                BuyerPhone = request.BuyerPhone
            };

            _context.Create(target);
            _context.Save();
        }
    }
}
