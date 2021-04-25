using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DAL;
using Microsoft.EntityFrameworkCore;
using BLL;
using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Cors;

namespace ASPNetCore.Controllers
{
    [Route("api/orderLines")]
    [ApiController]
    public class OrderLineController : ControllerBase
    {
        private readonly IDbCrud dbOp;

        public OrderLineController(IDbCrud dbCrud)
        {
            dbOp = dbCrud;
        }

        [HttpGet]
        public IEnumerable<OrderLineModel> GetAll()
        {
            return dbOp.GetAllOrderLines();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderLine = dbOp.GetOrderLine(id);
            return Ok(orderLine);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderLine([FromBody] OrderLineModel orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            orderLine.IdOrderLine = dbOp.CreateOrderLine(orderLine);

            return CreatedAtAction("GetProduct", new { id = orderLine.IdOrderLine }, orderLine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] OrderLineModel orderLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbOp.UpdateOrderLine(orderLine);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOrderLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dbOp.DeleteOrderLine(id);
            return NoContent();
        }
    }
}
