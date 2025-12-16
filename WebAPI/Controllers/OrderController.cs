using Application.Commands;
using Application.DTOs;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderQueries orderQueries) : BaseController
    {
        // GET: api/<OrderController>
        private readonly IOrderQueries _orderQueries = orderQueries;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _orderQueries.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await orderQueries.GetOrderAsync(id);
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}