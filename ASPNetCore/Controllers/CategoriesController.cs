using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using DAL;
using DAL;
using BLL.Interfaces;
using BLL.Models;

namespace ASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        //private readonly MarketContext _context;
        private readonly IDbCrud dbOp;

        public CategoriesController(IDbCrud dbOp)
        {
            this.dbOp = dbOp;
        }

        [HttpGet]
        // GET: Categories
        public IEnumerable<CategoryModel> GetAll()
        {
            //return _context.Category;
            return dbOp.GetAllCategories();
        }

        [HttpGet("{id}")]
        // GET: Categories/Details/5
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*var category = await _context.Category.SingleOrDefaultAsync(m => m.IdCategory == id);

            if (category == null)
            {
                return NotFound();
            }*/
            var category = dbOp.GetCategory(id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*_context.Category.Add(category);
            await _context.SaveChangesAsync();*/
            dbOp.CreateCategory(category);

            return CreatedAtAction("GetCategory", new { id = category.IdCategory }, category);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /*var item = _context.Category.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = category.Name;
            _context.Category.Update(item);
            await _context.SaveChangesAsync();*/
            dbOp.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            /*var item = _context.Category.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Category.Remove(item);
            await _context.SaveChangesAsync();*/
            dbOp.DeleteCategory(id);
            return NoContent();
        }
    }
}
