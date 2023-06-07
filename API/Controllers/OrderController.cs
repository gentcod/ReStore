using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities.OrderAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class OrderController : BaseApiController
    {
      private readonly StoreContext _context;
        public OrderController(StoreContext context)
        {
         _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var order = await _context.Orders
            .Include(o => o.OrderItems)
            .Where(x => x.BuyerId == User.Identity.Name)
            .ToListAsync();

            if (order == null) return NotFound();

            return order; 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _context.Orders
            .Include(o => o.OrderItems)
            .Where(x => x.BuyerId == User.Identity.Name && x.Id == id)
            .FirstOrDefaultAsync();

            return order;
        }
    }
}