using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BLL;
using BLL.Interfaces;
using BLL.Models;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Cors;

namespace ASPNetCore.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private readonly MarketContext _context;
        private readonly IDbCrud dbOp;

        public ProductsController(IDbCrud dbCrud)
        {
            dbOp = dbCrud;
            /*if (_context.Product.Count() == 0)
            {
                //_context.Product.Add(new Product {ProductId=1, CategoryId_FK=1, Expiration_date=240, Now_cost=50, Title="Milk", Category=new Category { CategoryId=1,Title= "Milk products", Product=null } });
                _context.Product.Add(new Product { IdProduct=1, IdCategoryFk=1, NowCost=50, ScorGodnostiO=50, Title="Milk" });
                _context.Product.Add(new Product { IdProduct = 2, IdCategoryFk = 2, NowCost = 25, ScorGodnostiO = 30, Title = "Limonade" });
                _context.SaveChanges();
            }*/
        }

        [HttpGet]
        public IEnumerable<ProductModel> GetAll()
        {
            return dbOp.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = dbOp.GetProduct(id);
            /*var product = await _context.Product.SingleOrDefaultAsync(m => m.IdProduct == id);

            if (product == null)
            {
                return NotFound();
            }*/
            return Ok(product);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbOp.CreateProduct(product);
            /*_context.Product.Add(product);
            await _context.SaveChangesAsync();*/

            return CreatedAtAction("GetProduct", new { id = product.IdProduct }, product);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /*var item = _context.Product.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.IdCategoryFk = product.IdCategoryFk;
            item.ScorGodnostiO = product.ScorGodnostiO;
            item.NowCost = product.NowCost;
            item.Title = product.Title;
            //item.Category = product.Category;
            _context.Product.Update(item);
            await _context.SaveChangesAsync();*/

            dbOp.UpdateProduct(product);

            return NoContent();
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /*var item = _context.Product.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Product.Remove(item);
            await _context.SaveChangesAsync();*/
            dbOp.DeleteProduct(id);
            return NoContent();
        }
    }
}
