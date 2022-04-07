using Bccupass_CoreMVC.Models.DTO.Ticket;
using Bccupass_CoreMVC.Models.ViewModel;
using Bccupass_CoreMVC.Models.ViewModel.User;
using Bccupass_CoreMVC.Services;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bccupass_CoreMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public UserController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserTicket(int userId)
        {

            int activePage = 1; // 目前在第幾頁
            int pageRows = 5; // 一頁幾筆資料

            userId = 1;
            var userTicketDto = _userService.GetOrderListOfUser(userId);

            var order = userTicketDto.Select(x => _ticketService.GetTicket(x.OrderId));

            var total = userTicketDto.Count();

            // 計算頁數
            int pages = 0;
            if (total % pageRows == 0)
            {
                pages = total / pageRows;
            }
            else
            {
                pages = (total / pageRows) + 1;
            }

            int startRow = (activePage - 1) * pageRows;



            var orderList = order.Select(x =>
                 new CreateTicketViewModel()
                 {
                     Order = new CreateTicketViewModel.OrderData
                     {
                         OrderId = x.Order.OrderId
                     },
                     TdOd = x.TdOd.Select(x => new CreateTicketViewModel.TicketDetailOrderDetail()
                     {
                         TdOdId = x.TdOdId,
                         BuyerName = x.BuyerName,
                         BuyerCompanyName = x.BuyerCompanyName,
                         BuyerPhone = x.BuyerPhone,
                         BuyerEmail = x.BuyerEmail
                     }),
                     TicketDetail = x.TicketDetail.Select(x => new CreateTicketViewModel.TicketDatail()
                     {
                         TicketId = x.TicketId,
                         TicketName = x.TicketName
                     }),
                     Activity = new CreateTicketViewModel.ActivityData
                     {
                         ActId = x.Activity.ActId,
                         ActName = x.Activity.ActName,
                         StartTime = x.Activity.StartTime,
                         EndTime = x.Activity.EndTime
                     },
                     TicketNum = _ticketService.TicketCount(x.Order.OrderId)
                 });

            var res = new UserTicketViewModel()
            {
                OrderList = orderList
            };

            return View(res);

            //var createTicketVM = new CreateTicketViewModel()
            //{
            //    User = new UserTicketViewModel.UserData { UserId = userTicketDto.User.UserId },
            //    Order = userTicketDto.Order.Select(x => new UserTicketViewModel.OrderData()
            //    {
            //        OrderId = x.OrderId,
            //    }),
            //    TdOd = userTicketDto.TdOd.Select(x => new UserTicketViewModel.TicketDetailOrderDetail()
            //    {
            //        TdOdId = x.TdOdId,
            //        BuyerName = x.BuyerName,
            //        BuyerCompanyName = x.BuyerCompanyName,
            //        BuyerPhone = x.BuyerPhone,
            //        BuyerEmail = x.BuyerEmail
            //    }),
            //    TicketDetail = userTicketDto.TicketDetail.Select(x => new UserTicketViewModel.TicketDatail()
            //    {
            //        TicketId = x.TicketId,
            //        TicketName = x.TicketName,
            //        Price = x.Price
            //    }),
            //    Activity = userTicketDto.Activity.Select(x => new UserTicketViewModel.ActivityData()
            //    {
            //        ActId = x.ActId,
            //        ActName = x.ActName,
            //        StartTime = x.StartTime,
            //        EndTime = x.EndTime
            //    })
            //};

            //return View(userTicketVM);


        }

    }
}
