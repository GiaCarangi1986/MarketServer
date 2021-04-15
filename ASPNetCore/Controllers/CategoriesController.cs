using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetCore.Model;

namespace ASPNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly MarketContext _context;

        public CategoriesController(MarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        // GET: Categories
        public IEnumerable<Category> GetAll()
        {
            return _context.Category;
        }

        [HttpGet("{id}")]
        // GET: Categories/Details/5
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Category.SingleOrDefaultAsync(m => m.IdCategory == id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.IdCategory }, category);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Category.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = category.Name;
            _context.Category.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Category.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Category.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
