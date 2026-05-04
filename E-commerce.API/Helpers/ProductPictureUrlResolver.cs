using AutoMapper;
using E_commerce.API.Dtos;
using E_commerce.Core.Entities;

namespace E_commerce.API.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    { 
        public IConfiguration _configuration { get; }
        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl))
                return $"{_configuration["BaseApiUrl"]}{source.ImageUrl}";

            return string.Empty;
        }
    }
}
