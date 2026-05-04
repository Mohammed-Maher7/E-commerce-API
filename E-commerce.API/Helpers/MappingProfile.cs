using AutoMapper;
using E_commerce.API.Dtos;
using E_commerce.Core.Entities;

namespace E_commerce.API.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, O => O.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, O => O.MapFrom(s => s.Category.Name));
        }
    }
}
