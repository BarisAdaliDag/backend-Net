using _40_API_Entity.Contexts;
using _40_API_Entity.Models;
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
                    return NotFound(new { Message = $"{id} id'li urun bulunamadi" });

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"veritabanindan veri cekilemedi", Details = ex.Message });
            }
        }

        [HttpGet("filter")]
        public IActionResult GetAllProduct(
        [FromQuery] string? q,
        [FromQuery] int? categoryId,
        [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice,
        [FromQuery] string? sort = "name_asc", // name_asc | name_desc | price_asc | price_desc
        [FromQuery] int pageIndex = 1,
        [FromQuery] int pageSize = 5
    )
        {
            IQueryable<Product> query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking();

            // Arama
            if (!string.IsNullOrEmpty(q))
                query = query.Where(p => p.Name.Contains(q) ||
                                         (p.Description != null && p.Description.Contains(q)));

            // Kategori filtresi
            if (categoryId is not null)
                query = query.Where(p => p.CategoryId == categoryId);

            // Fiyat aralık filtresi
            if (minPrice is not null)
                query = query.Where(p => p.Price >= minPrice);

            if (maxPrice is not null)
                query = query.Where(p => p.Price <= maxPrice);

            // Sıralama
            query = sort switch
            {
                "name_desc" => query.OrderByDescending(p => p.Name),
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name) // varsayılan: name_asc
            };

            // Sayfalama
            var totalCount = query.Count();
            var items = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new
            {
                TotalCount = totalCount,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Data = items
            });
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest(new { Message = "Ürün bilgisi boş olamaz." });

            //    Geçerli kategori var mı kontrol et
                var categoryExists = _context.Categories.Any(c => c.Id == product.CategoryId);
                if (!categoryExists)
                    return BadRequest(new { Message = $"Geçersiz kategori ID: {product.CategoryId}" });

                // Ürünü ekle
                _context.Products.Add(product);
                _context.SaveChanges();

                // Oluşturulan ürünün bilgilerini döndür (201 Created)
                return CreatedAtAction(nameof(GetProductById),
                    new { id = product.Id },
                    product);

            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Message = $"Veritabanina veri eklenmedi ",Details = ex.Message });
            }
        }


    }
}