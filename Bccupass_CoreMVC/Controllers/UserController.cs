using Bccupass_CoreMVC.Common.Enum;
using Bccupass_CoreMVC.Models.DTO.Ticket;
using Bccupass_CoreMVC.Models.ViewModel;
using Bccupass_CoreMVC.Models.ViewModel.User;
using Bccupass_CoreMVC.Services;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Bccupass_CoreMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;
        private static int totalRows;


        public UserController(ITicketService ticketService, IUserService userService )
        {
            _ticketService = ticketService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserTicket(int userId, int selcetByOrderState,int page=1)
        {
            int activePage = page;
            int pageRows = 4;

            int Pages = 0;


            //userId = int.Parse(User.Identity?.Name);
            userId = 1;
            var userTicketDto = _userService.GetOrderListOfUser(userId);
            var order = userTicketDto.Select(x => _ticketService.GetTicket(x.OrderId));
            var total = userTicketDto.Count();

            var orderList = order.Select(x =>
                 new ShowTicketViewModel()
                 {
                     Order = new ShowTicketViewModel.OrderData
                     {
                         OrderId = x.Order.OrderId,
                         OrderTime=x.Order.OrderTime,
                         OrderState=x.Order.OrderState,

                     },
                     TdOd = x.TicketInOrder.Select(x => new ShowTicketViewModel.TicketDetailOrderDetail()
                     {
                         TdOdId = x.TdOdId,
                         BuyerName = x.BuyerName,
                         BuyerCompanyName = x.BuyerCompanyName,
                         BuyerPhone = x.BuyerPhone,
                         BuyerEmail = x.BuyerEmail
                     }),
                     TicketDetail = x.TicketDetail.Select(x => new ShowTicketViewModel.TicketDatail()
                     {
                         TicketId = x.TicketId,
                         TicketName = x.TicketName,
                         CheckStart = x.CheckStart,
                         CheckEnd = x.CheckEnd,
                         Price=x.Price,
                     }),
                     Activity = new ShowTicketViewModel.ActivityData
                     {
                         ActId = x.Activity.ActId,
                         ActName = x.Activity.ActName,
                         StartTime = x.Activity.StartTime,
                         EndTime = x.Activity.EndTime
                     },
                     TicketNum = _ticketService.TicketCount(x.Order.OrderId)
                 });

            switch (selcetByOrderState)
            {
                case (int)OrderState.Paid:
                    orderList = orderList.Where(x=>x.Order.OrderState == selcetByOrderState).ToList();
                    break;
                case (int)OrderState.NotPaid:
                    orderList = orderList.Where(x => x.Order.OrderState == selcetByOrderState).ToList();
                    break;
                case (int)OrderState.Cancel:
                    orderList = orderList.Where(x => x.Order.OrderState == selcetByOrderState).ToList();
                    break;
                case (int)OrderState.Refund:
                    orderList = orderList.Where(x => x.Order.OrderState == selcetByOrderState).ToList();
                    break;
            }

            if (totalRows == 0)
            {
                totalRows = orderList.Count();
            }

            if (totalRows % pageRows == 0)
            {
                Pages = totalRows / pageRows;
            }
            else
            {
                Pages = (totalRows / pageRows) + 1;
            }

            int startRow = (activePage - 1) * pageRows;

            orderList= orderList.OrderBy(x => x.Order.OrderTime).Skip(startRow).Take(pageRows);


            var res = new UserTicketViewModel()
            {
                OrderList = orderList
            };

            ViewData["ActivePage"] = page;//Active分頁碼
            ViewData["Pages"] = Pages; //總頁數

            return View(res);

        }

    }
}
