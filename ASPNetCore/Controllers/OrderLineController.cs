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

        [HttpGet("user/{userId}")]
        public IEnumerable<OrderLineModel> GetAll([FromRoute] string userId)
        {
            List<OrderLineModel> orderLines = new List<OrderLineModel>();
            List<DeliveryLineModel> deliveryLines = new List<DeliveryLineModel>();
            List<OrderModel> orders = new List<OrderModel>();

            deliveryLines = dbOp.GetAllDeliveryLines();
            orderLines = dbOp.GetAllOrderLines();
            orders = dbOp.GetAllOrders();

            //делаем это, чтобы получить CountMax - кол-во продуктов из данной поставки
            var result = orderLines.Join(deliveryLines,
                o => o.IdProductFk,
                d => d.IdProductFk,
                (o, d) => new { CountMax = d.RemainingProduct, IdProductFk = o.IdProductFk, IdOrderFk=o.IdOrderFk });
            List<OrderLineModel> copy = new List<OrderLineModel>();

            //получаем данные о корзине для конкретного пользователя (userId)
            var result_ = result.Join(orders,
                r_ => r_.IdOrderFk,
                r => r.IdOrder,
                (r_, r) => new { r.IdUserFk, r_.CountMax, r_.IdProductFk, r.IdOrder });

            bool ok = false;
            foreach (var item in result_)
            {
                if (item.IdUserFk == userId)
                foreach (var temp in orderLines.Where(i=>i.IdOrderFk==item.IdOrder))
                {
                    if (item.IdProductFk == temp.IdProductFk)
                    {
                        var dop = temp;
                        dop.CountMax = item.CountMax;
                        copy.Add(dop);
                        
                        //int index = orderLines.IndexOf(temp);
                        //orderLines.ElementAt(index).CountMax = item.CountMax;
                        ok = true;
                    }
                }
            }
            if (!ok)
                copy = null;

            return copy;
        }

        [HttpGet("{id}/{userId}")]
        public async Task<IActionResult> GetOrderLine([FromRoute] int id, [FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OrderModel order = new OrderModel();
            order = dbOp.GetAllOrders().Where(i=>i.IdUserFk == userId).FirstOrDefault();

            int ok = 2; //не найдено
            var orderList = dbOp.GetAllOrderLines();
            foreach (var item in orderList)
            {
                if (item.IdProductFk == id && order.IdOrder==item.IdOrderFk)
                {
                    ok = 1; //найдено
                    break;
                }
            }

            return Ok(ok);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateOrderLine([FromBody] ProductModel product, [FromRoute] string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OrderModel order = new OrderModel();
            order = dbOp.GetAllOrders().Where(i => i.IdUserFk == userId).FirstOrDefault();

            OrderLineModel orderLine = new OrderLineModel();
            orderLine.IdProductFk = product.IdProduct;
            orderLine.MuchOfProducts = 1;
            orderLine.CostForBuyer = product.NowCost;


            orderLine.IdOrderFk = order.IdOrder; //не знаю как сделать так, чтобы доставать id из корзины для текущего пользователя

            orderLine.IdOrderLine = dbOp.CreateOrderLine(orderLine);

            return CreatedAtAction("GetOrderLine", new { id = orderLine.IdOrderLine, userId = userId }, orderLine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(OrderLineModel orderLine)
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
