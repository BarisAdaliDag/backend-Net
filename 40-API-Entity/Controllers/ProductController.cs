using _40_API_Entity.Contexts;
using _40_API_Entity.Models;
using _40_API_Entity.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _40_API_Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            try
            {
                var products = _context.Products.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"veritabanindan veri cekilemedi", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == id);

                if (product == null)
                { //hocat yer farkli olabilir
                   
                    return NotFound(new { Message = $"{id} id'li urun bulunamadi" });

                }
                var productDTO = new ProductDTO();



                Response.Headers.ETag = $"W/\"{Convert.ToBase64String(product.RowVersion)}\"";
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"veritabanindan veri cekilemedi", Details = ex.Message });
            }
        }
        [HttpGet("filter")]
        public IActionResult GetAllProduct(
                 [FromQuery] string? q, //search
                 [FromQuery] int? categoryId,
                 [FromQuery] decimal? minPrice,
                 [FromQuery] decimal? maxPrice,
                 [FromQuery] string? sort = "name_asc", //name_asc|name_desc|price_asc|price_desc,
                 [FromQuery] int pageIndex = 1,
                 [FromQuery] int pageSize = 5
                 )
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(q))
                query = query.Where(p => p.Name.Contains(q) || p.Description != null && p.Description.Contains(q));

            if (categoryId is not null)
                query = query.Where(p => p.CategoryId == categoryId);

            if (minPrice is not null)
                query = query.Where(p => p.Price >= minPrice);

            if (maxPrice is not null)
                query = query.Where(p => p.Price <= maxPrice);

            query = sort switch
            {
                "name_desc" => query.OrderByDescending(p => p.Name),
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name),
            };

            var total = query.Count();
            var items = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new { Count = total, Page = pageIndex, Size = pageSize, Data = items });
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Product product = new Product()
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    CategoryId = productDTO.CategoryId,
                    Description = productDTO.Description,
                };
                _context.Products.Add(product);
                _context.SaveChanges();

                Response.Headers.ETag = $"W/\"{Convert.ToBase64String(product.RowVersion)}\"";

                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanına veri eklenemedi!", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {

        }
    }
}
