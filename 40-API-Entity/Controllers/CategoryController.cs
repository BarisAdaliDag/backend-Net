using _40_API_Entity.Contexts;
using _40_API_Entity.Models;
using _40_API_Entity.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _40_API_Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            try
            {
                var products = _context.Categories.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanından veri çekilemedi!", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById([FromRoute] int id)
        {
            try
            {
                var product = _context.Categories.FirstOrDefault(x => x.Id == id);

                if (product == null)
                    return NotFound(new { Message = $"{id} nolu kategori bulunamadı!" });

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanından veri çekilemedi!", Details = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Category category = new Category { Name = categoryDTO.Name };
                _context.Categories.Add(category);
                _context.SaveChanges();

            
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanına veri eklenemedi!", Details = ex.Message });
            }
        }

    }
}
