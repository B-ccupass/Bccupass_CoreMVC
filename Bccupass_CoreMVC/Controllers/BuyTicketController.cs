using Bccupass_CoreMVC.Models.ViewModel.Ticket;
using Bccupass_CoreMVC.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                BuyMostCount = x.Price == 0 ? 1 : x.BuyMostCount,
                BuyLeastCount = x.BuyLeastCount,
                BuyCount = 0
            });

            var result = new TicketPurchaseViewModel()
            {
                ActivityList = activityView,
                TicketList = ticketView
            };

            return View(result);
        }

        [HttpPost]
        public IActionResult submitCart([FromBody] CartDataModel request)
        {
            TempData["CartData"] = JsonConvert.SerializeObject(request);
            return new JsonResult(new { isSuccess = true });
        }

        public IActionResult BuyerForm()
        {
            if (!TempData.ContainsKey("CartData"))
            {
                return RedirectToAction("Error");
            }

            string json = (string)TempData["CartData"];
            var cartData = JsonConvert.DeserializeObject<CartDataModel>(json);
            var activity = _activity.GetActivityById(cartData.ActivityId);
            var activityView = new FormViewModel.ActivityData()
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
            var target = _ticket.GetTicketFormByActivityId(cartData.ActivityId);
            var form = new FormViewModel.FormBoolData()
            {
                Name = target.Name,
                Email = target.Email,
                Phone = target.Phone,
                BirthDay = target.BirthDay,
                Address = target.Address,
                Gender = target.Gender,
                Age = target.Age,
                Hobby = target.Hobby,
                MaritalStatus = target.MaritalStatus,
                Industry = target.Industry,
                Department = target.Department,
                IdNumber = target.IdNumber,
                Fax = target.Fax,
                EducationLevel = target.EducationLevel,
                DiningNeeds = target.DiningNeeds,
                CompanyName = target.CompanyName,
                JobTitle = target.JobTitle,
            };

            var result = new FormViewModel()
            {
                ActivityList = activityView,
                FormBool = form,
                CartData = cartData,
            };

            return View(result);
        }
    }
}
