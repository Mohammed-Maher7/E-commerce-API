using E_commerce.Core.Entities;

namespace E_commerce.API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }  
        public string Category { get; set; }   

        public int BrandId { get; set; }
        public string Brand { get; set; }
    }
}
