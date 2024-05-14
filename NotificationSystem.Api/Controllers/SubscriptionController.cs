using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Contract;

namespace NotificationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriberService _Service;
        public SubscriptionController(ISubscriberService service)
        {
            _Service = service;
        }
        [HttpPost("Subscription")]
        public async Task<IActionResult> CreateSubscription([FromBody] NewSubscriptionDto request)
        {
            var result = await _Service.Subscription(request.Subscriber, request.Subscriptions, request.Voucher);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
