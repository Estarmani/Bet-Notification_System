using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Contract;
using NotificationSystem.Domain.Subscription;
using NotificationSystem.Models;
using System.Diagnostics;

namespace NotificationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISubscriberService _SubscriberService;

        public HomeController(ILogger<HomeController> logger, ISubscriberService subscriberService)
        {
            _logger = logger;
            _SubscriberService = subscriberService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new SubscriptionModel();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SubscriptionModel request)
        {
            //if (!ModelState.IsValid) return View(request);
            var subsciption = new SubscriptionDto { Package = request.Package, SubscriptionType = request.SubscriptionType };
            var subscriber = new SubscriberDto { MobileNumber = request.MobileNumber };
            var voucher = new VoucherDto { PinNumber = request.PinNumber };
           var result = await _SubscriberService.Subscription(subscriber, subsciption, voucher); 

            if (result == null )return View(request);
            
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
