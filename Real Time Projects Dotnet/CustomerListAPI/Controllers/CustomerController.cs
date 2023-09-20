using System;
using System.Collections.Generic;
using System.Linq;
using CustomerListAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly TestDbContext _context;

        public CustomersController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("{customerId}/orders")]
        public ActionResult<IEnumerable<Customer>> GetOrdersForCustomer(int customerId)
        {
            var ordersForCustomer = _context.Customers
                .Where(customer => customer.customerId == customerId)
                .Select(customer => new Customer
                {
                    orderId = customer.orderId,
                    orderName = customer.orderName
                })
                .ToList();

            return Ok(ordersForCustomer);
        }

        [HttpGet("summary")]
        public ActionResult<IEnumerable<Customer>> GetSummary()
        {
            var summary = _context.Customers
                .GroupBy(customer => new { customer.country, customer.customerId })
                .OrderBy(group => group.Key.country)
                .Select(group => new Summary
                {
                    CustomerId = group.Key.customerId,
                    Country = group.Key.country,
                    TotalOrders = group.Count(),
                    TotalAmount = group.Sum(customer => customer.totalAmount) // Replace with the actual field used for order amount
                })
                .ToList();

            return Ok(summary);
        }
    }
}
