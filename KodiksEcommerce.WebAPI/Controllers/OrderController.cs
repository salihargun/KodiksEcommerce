using KodiksEcommerce.Data.EntityFreamwork.Entities;
using KodiksEcommerce.Service.Order.Service;
using KodiksEcommerce.Service.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodiksEcommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var Products = await _orderService.GetAllOrdersAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetProductById(int id)
        {
            var Product = await _orderService.GetOrderByIdAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateProduct(Order order)
        {
            await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetProductById), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
