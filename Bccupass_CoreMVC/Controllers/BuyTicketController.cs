using Bccupass_CoreMVC.Models.ViewModel.Ticket;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bccupass_CoreMVC.Controllers
{
    public class BuyTicketController : Controller
    {
        private readonly IActivityService _activity;
        private readonly ITicketService _ticket;

        public BuyTicketController(IActivityService activity, ITicketService ticket)
        {
            _activity = activity;
            _ticket = ticket;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TicketList(int id)
        {
            var activity = _activity.GetActivityById(id);
            var ticket = _ticket.GetTicketInfoAtPurchase(id);

            var activityView = new TicketPurchaseViewModel.ActivityData()
            {
                ActivityId = activity.Id,
                ActivityName = activity.Name,
                Image = activity.Image,
                StartTime = activity.StartTime,
                EndTime = activity.EndTime,
                City = activity.City,
                District = activity.District,
                Address = activity.Address
            };

            var ticketView = ticket.Select(x => new TicketPurchaseViewModel.TicketData()
            {
                TicketId = x.TicketId,
                TicketName = x.TicketName,
                Price = x.Price,
                Quantity = x.Quantity,
                Description = x.Description,
                SellStartTime = x.SellStartTime,
                SellEndTime = x.SellEndTime,
                CheckStartTime = x.CheckStartTime,
                CheckEndTime = x.CheckEndTime,
                GroupName = x.GroupName,
                BuyMostCount = x.BuyMostCount,
                BuyLeastCount = x.BuyLeastCount,
            });

            var result = new TicketPurchaseViewModel()
            {
                ActivityList = activityView,
                TicketList = ticketView
            };

            return View(result);
        }
    }
}
