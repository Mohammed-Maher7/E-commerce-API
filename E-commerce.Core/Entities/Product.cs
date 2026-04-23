using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Core.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }  //foreign key 
        public ProductCategory Category  { get; set; }  //navigation property

        public int BrandId { get; set; }
        public ProductBrand Brand { get; set; }


    }
}
