using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderPricingSystem.Models;
using OrderPricingSystem.Services;

namespace OrderPricingSystem.Controllers
{
    [Route("api/[controller]")] //api/pricing
    [ApiController]
    public class PricingController : ControllerBase
    {
        private PricingService _service;

        public PricingController()
        {
            _service = new PricingService();
        }

        [HttpGet("calculate")] //api/pricing/calculate
        public IActionResult Calculate([FromQuery] OrderRequest orderRequest) 
        {
            try
            {
                var response = _service.CalculatePrice(orderRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
