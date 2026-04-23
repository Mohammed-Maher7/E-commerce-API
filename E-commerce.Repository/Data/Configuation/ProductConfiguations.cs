using E_commerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repository.Data.Configuation
{
    public class ProductConfiguations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name)
                .IsRequired();

            builder.Property(P=>P.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(P => P.Description)
                .IsRequired();

            builder.Property(P => P.ImageUrl)
                .IsRequired();

            builder.HasOne(P=>P.Category)
                .WithMany()
                .HasForeignKey(P=>P.CategoryId);

            builder.HasOne(P=>P.Brand)
                .WithMany()
                .HasForeignKey(P=>P.BrandId);

        }
    }
}
