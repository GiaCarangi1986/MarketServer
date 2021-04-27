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
            List<OrderLineModel> orderLines = new List<OrderLineModel>();
            List<DeliveryLineModel> deliveryLines = new List<DeliveryLineModel>();

            deliveryLines = dbOp.GetAllDeliveryLines();
            orderLines = dbOp.GetAllOrderLines();

            //делаем это, чтобы получить CountMax - кол-во продуктов из данной поставки
            var result = orderLines.Join(deliveryLines,
                o => o.IdProductFk,
                d => d.IdProductFk,
                (o, d) => new { CountMax = d.RemainingProduct , IdProductFk = o.IdProductFk });

            int i = 0, j=0;
            for (var item = result.First(); i<result.Count(); i++)
            {
                for (var temp = orderLines.First(); j < orderLines.Count(); j++)
                {
                    if (item.IdProductFk == temp.IdProductFk)
                        orderLines.ElementAt(j).CountMax = result.ElementAt(i).CountMax;
                }
            }

            return orderLines;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderLine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int ok = 2; //не найдено
            var orderList = dbOp.GetAllOrderLines();
            foreach (var item in orderList)
            {
                if (item.IdProductFk == id)
                {
                    ok = 1; //найдено
                    break;
                }
            }

            return Ok(ok);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderLine([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderLineModel orderLine = new OrderLineModel();
            orderLine.IdProductFk = product.IdProduct;
            orderLine.MuchOfProducts = 1;
            orderLine.CostForBuyer = product.NowCost;
            orderLine.IdOrderFk = 2; //не знаю как сделать так, чтобы доставать id из корзины для текущего пользователя

            orderLine.IdOrderLine = dbOp.CreateOrderLine(orderLine);

            return CreatedAtAction("GetOrderLine", new { id = orderLine.IdOrderLine }, orderLine);
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
