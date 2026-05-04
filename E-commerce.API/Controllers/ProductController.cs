using E_commerce.Core.Entities;
using E_commerce.Core.Interfaces;
using E_commerce.Core.Specifications.Specs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            ProductWithBrandAndCategorySpecifications specs = new ProductWithBrandAndCategorySpecifications(P=>P.Id==id);
            var product = await _productRepo.GetByIdWithSpecsAsync(id, specs);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProducts() 
        {
            ProductWithBrandAndCategorySpecifications specs = new ProductWithBrandAndCategorySpecifications();
            var products = await _productRepo.GetAllWithSpecsAsync(specs);
          
            return (products == null) ?  NotFound() : Ok(products);
            
        }
    }
}
