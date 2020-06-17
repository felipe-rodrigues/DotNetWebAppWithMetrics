using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMetrics.Database;
using WebAppMetrics.Metrics;
using WebAppMetrics.Models;

namespace WebAppMetrics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerContext _ctx;
        private readonly IMetrics _metrics;

        public CustomerController(CustomerContext ctx, IMetrics metrics)
        {
            _ctx = ctx;
            _metrics = metrics;
        }


        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            _metrics.Measure.Counter.Increment(RequestMetrics.GetCustomersCounter);
            return await _ctx.Customer.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {

            try
            {
                _ctx.Customer.Add(customer);
                await _ctx.SaveChangesAsync();

                _metrics.Measure.Counter.Increment(RequestMetrics.CreateCustomersCounter);
                return Ok(customer);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
