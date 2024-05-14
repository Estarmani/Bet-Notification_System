
using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Contract._Core;
using NotificationSystem.Contract.Vouchers;

namespace NotificationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherProdServices _Services;
        public VoucherController(IVoucherProdServices services)
        {
            _Services = services;

        }
        [HttpPost("VoucherProduction")]
        public async Task<IActionResult> VoucherProduction([FromBody] VoucherProductionDto production)
        {
            var result = await _Services.CreateVoucher(production);
            if (result == null) return BadRequest();
            return Ok(result);
            
        }
    }
}
