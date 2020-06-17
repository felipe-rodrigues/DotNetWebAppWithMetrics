using App.Metrics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAppMetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IMetrics _metrics;

        public PaymentController(IMetrics metrics)
        {
            _metrics = metrics;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment()
        {
            return Ok();
        }

        [HttpPost("error")]
        public async Task<IActionResult> CreatePaymentError()
        {
            var errors = new int[]
            {
                14,17,57,99
            };

            var random = new Random();

            var randomError = random.Next(0, errors.Length - 1);

            return StatusCode(500);
        }
    }
}
