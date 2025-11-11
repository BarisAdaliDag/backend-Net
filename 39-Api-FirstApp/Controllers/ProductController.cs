using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _39_Api_FirstApp.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<string>_products = new List<string>() { "Mouse","Keyborad"};

        //public List<string> Products()
        //{
        //    return _products;
        //}
     
        //[HttpGet]
        //public IActionResult Products( int id)
        //{
        //    // return Ok(_products);
        //    return StatusCode(200, _products);
        //}

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            if (_products == null || _products.Count <= 0)
            {
                return NoContent();
            }
             return Ok(_products);
        }
        [HttpGet("{id}")]
        public IActionResult GetAllProductById([FromRoute]int id)
        {
            if (_products == null || id >= _products.Count )
            {
                return NotFound("urun bulunamadi");
            }
            return Ok(_products[id]);//Urun bulunursa 200
        }


    }
}
