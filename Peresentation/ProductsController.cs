using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
   public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]  // GET: /api/products
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await serviceManager.ProductService.GetAllProductsAsync();

            if (result == null)
                return BadRequest(); // 400

            return Ok(result); // 200
        }

        [HttpGet("{id}")] // GET: /api/products/12
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await serviceManager.ProductService.GetProductByIdAsync(id);

            if (result is null)
                return NotFound(); // 404

            return Ok(result); // 200
        }


        // Get All Brands
        [HttpGet("brands")] // GET: /api/products/brands
        public async Task<IActionResult> GetAllBrands()
        {
            var result = await serviceManager.ProductService.GetAllBrandsAsync();
            if (result is null )
                return NotFound(); // 404 - More appropriate than BadRequest when no items found

            return Ok(result); // 200
        }

        // Get All Types
        [HttpGet("types")] // GET: /api/products/types
        public async Task<IActionResult> GetAllTypes()
        {
            var result = await serviceManager.ProductService.GetAllTypesAsync();
            if (result is null )
                return NotFound(); // 404 - More appropriate than BadRequest when no items found

            return Ok(result); // 200
        }



    }
}
