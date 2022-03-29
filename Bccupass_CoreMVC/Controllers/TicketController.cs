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

        public IActionResult CreateTicket(int id)
        {
            id = 1;
            var createTicketDto = _ticketService.GetTicket(id);
            var createTicketVM = new CreateTicketViewModel()
            {
                Order = new CreateTicketViewModel.OrderData
                {
                    OrderId = createTicketDto.Order.OrderId
                },
                TdOd = createTicketDto.TdOd.Select(x => new CreateTicketViewModel.TicketDetailOrderDetail()
                {
                    TdOdId = x.TdOdId,
                    BuyerName = x.BuyerName,
                    BuyerEmail = x.BuyerEmail,
                    BuyerPhone = x.BuyerPhone,
                    BuyerCompanyName = x.BuyerCompanyName
                }),
                TicketDetail = createTicketDto.TicketDetail.Select(x => new CreateTicketViewModel.TicketDatail()
                {
                    TicketId = x.TicketId,
                    TicketName = x.TicketName
                }),
                Activity = new CreateTicketViewModel.ActivityData
                {
                    ActId = createTicketDto.Activity.ActId,
                    ActName = createTicketDto.Activity.ActName
                },
                Organizer = new CreateTicketViewModel.OrganizerData
                {
                    OrgId = createTicketDto.Organizer.OrgId,
                    OrgName = createTicketDto.Organizer.OrgName,
                    OrgEmail = createTicketDto.Organizer.OrgEmail,
                    OrgPhone = createTicketDto.Organizer.OrgPhone, 
                }

            };

            return View(createTicketVM);
        }

    }
}
