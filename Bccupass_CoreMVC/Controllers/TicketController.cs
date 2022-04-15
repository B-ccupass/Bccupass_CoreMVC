using Microsoft.AspNetCore.Mvc;
using Bccupass_CoreMVC.Models.ViewModel;
using Bccupass_CoreMVC.Services.Interface;
using System.Linq;

namespace Bccupass_CoreMVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowTicket(int id)
        {
            var createTicketDto = _ticketService.GetTicket(id);
            var createTicketVM = new ShowTicketViewModel()
            {
                Order = new ShowTicketViewModel.OrderData
                {
                    OrderId = createTicketDto.Order.OrderId
                },
                TdOd = createTicketDto.TicketInOrder.Select(x => new ShowTicketViewModel.TicketDetailOrderDetail()
                {
                    TdOdId = x.TdOdId,
                    BuyerName = x.BuyerName,
                    BuyerCompanyName = x.BuyerCompanyName,
                    BuyerPhone = x.BuyerPhone,
                    BuyerEmail = x.BuyerEmail
                }),
                TicketDetail = createTicketDto.TicketDetail.Select(x => new ShowTicketViewModel.TicketDatail()
                {
                    TicketId = x.TicketId,
                    TicketName = x.TicketName
                }),
                Activity = new ShowTicketViewModel.ActivityData
                {
                    ActId = createTicketDto.Activity.ActId,
                    ActName = createTicketDto.Activity.ActName,
                    StartTime = createTicketDto.Activity.StartTime,
                    EndTime = createTicketDto.Activity.EndTime
                },
                Organizer = new ShowTicketViewModel.OrganizerData
                {
                    OrgId = createTicketDto.Organizer.OrgId,
                    OrgName = createTicketDto.Organizer.OrgName,
                    OrgEmail = createTicketDto.Organizer.OrgEmail,
                    OrgPhone = createTicketDto.Organizer.OrgPhone, 
                },
                TicketNum = _ticketService.TicketCount(id)
            };

            return View(createTicketVM);
        }

    }
}
