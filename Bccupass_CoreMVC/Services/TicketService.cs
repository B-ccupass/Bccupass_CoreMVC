﻿using Bccupass_CoreMVC.Models.DBEntity;
using Bccupass_CoreMVC.Models.DTO;
using Bccupass_CoreMVC.Repositories.Interface;
using Bccupass_CoreMVC.Services.Interface;
using Bccupass_CoreMVC.Models.DTO.Ticket;
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


        public ShowTicketDto GetTicket(int orderDetailId)
        {
            return new ShowTicketDto()
            {
                Order = GetOrderData(orderDetailId),
                TicketInOrder = GetTicketInOrderByOrderDetailId(orderDetailId),
                TicketDetail = GetTickeDetailByOrderDetailId(orderDetailId),
                Activity = GetActivityDataByOrderDetailId(orderDetailId),
                Organizer = GetOrganizerDataByOrderDetailId(orderDetailId),
            };
        }

        public int TicketCount(int orderDetailId)
        {
            var num = _context.GetAll<TicketDetailOrderDetail>().Where(x => x.OrderDetailId == orderDetailId).Count();

            return num;
        }


        //獲取訂單相關資料

        private ShowTicketDto.OrderData GetOrderData(int orderDetailId)
        {
            var order = _context.GetAll<OrderDetail>().First(x => x.OrderDetailId == orderDetailId);
            return new ShowTicketDto.OrderData()
            {
                OrderId = order.OrderDetailId,
                OrderState =order.OrderState,
                OrderTime = order.OrderTime,
            };
        }

        private IEnumerable<ShowTicketDto.TicketDatail> GetTickeDetailByOrderDetailId(int orderDetailId)
        {
            var res = _context.GetAll<TicketDetailOrderDetail>().Where(x => x.OrderDetailId == orderDetailId).Select(x => x.TicketDetailId);
            return _context.GetAll<TicketDatail>().Where(x => res.Any(y => y == x.TicketDatailId)).Select(x => new ShowTicketDto.TicketDatail()
            {
                TicketId = x.TicketDatailId,
                TicketName = x.TicketName,
                Price = x.Price,
                CheckStart=x.CheckStartTime,
                CheckEnd=x.CheckEndTime,
            });
        }
        private IEnumerable<ShowTicketDto.TicketDetailOrderDetail> GetTicketInOrderByOrderDetailId(int orderDetailId)
        {
            return _context.GetAll<TicketDetailOrderDetail>().Where(x => x.OrderDetailId== orderDetailId).Select(x => new ShowTicketDto.TicketDetailOrderDetail()
            {
                TdOdId = x.TicketDetailOrderDetailId,
                BuyerName = x.BuyerName,
                BuyerEmail = x.BuyerEmail,
                BuyerPhone = x.BuyerPhone,
                BuyerCompanyName = x.BuyerConpanyName
            });


        }

        private ShowTicketDto.ActivityData GetActivityDataByOrderDetailId(int orderDetailId)
        {
            var order = _context.GetAll<OrderDetail>().First(x => x.OrderDetailId == orderDetailId);
            var act = _context.GetAll<Activity>().First((x => x.ActivityId == order.ActivityId));
            return new ShowTicketDto.ActivityData()
            {
                ActId = act.ActivityId,
                ActName = act.Name,
                StartTime = act.StartTime,
                EndTime = act.EndTime,
            };
        }

        private ShowTicketDto.OrganizerData GetOrganizerDataByOrderDetailId(int orderDetailId)
        {
            var order = _context.GetAll<OrderDetail>().First(x => x.OrderDetailId == orderDetailId);
            var act = _context.GetAll<Activity>().First((x => x.ActivityId == order.ActivityId));
            var org = _context.GetAll<Organizer>().First((x => x.OrganizerId == act.OrganizerId));
            return new ShowTicketDto.OrganizerData()
            {
                OrgId = org.OrganizerId,
                OrgName = org.Name,
                OrgEmail = org.Email,
                OrgPhone = org.Telphone
            };
        }


    }
}
