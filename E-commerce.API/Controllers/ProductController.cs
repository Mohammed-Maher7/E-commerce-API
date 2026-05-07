using AutoMapper;
using E_commerce.API.Dtos;
using E_commerce.API.Errors;
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
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            ProductWithBrandAndCategorySpecifications specs = new ProductWithBrandAndCategorySpecifications(P=>P.Id==id);
            var product = await _productRepo.GetByIdWithSpecsAsync(id, specs);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            else
            {
                var mappedProduct = _mapper.Map<Product, ProductToReturnDto>(product);
                return Ok(mappedProduct);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts() 
        {
            ProductWithBrandAndCategorySpecifications specs = new ProductWithBrandAndCategorySpecifications();
            var products = await _productRepo.GetAllWithSpecsAsync(specs);

            if (products == null)
            {
                return NotFound(new ApiResponse(404));
            }
            else
            {
                var mappedProducts = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products);
                return Ok(mappedProducts);
            }

        }
    }
}
