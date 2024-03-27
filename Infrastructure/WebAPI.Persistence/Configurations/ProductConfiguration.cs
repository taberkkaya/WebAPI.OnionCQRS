using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Common;
using WebAPI.Domain.Entities;

namespace WebAPI.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new();

            Product product1 = new()
            {
                Id = 1,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                BrandId = 1,
                Price = faker.Random.Decimal(0, 10),
                Discount = faker.Finance.Amount(10, 1000),
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Product product2 = new()
            {
                Id = 2,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                BrandId = 1,
                Price = faker.Random.Decimal(0, 10),
                Discount = faker.Finance.Amount(10, 1000),
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };
            Product product3 = new()
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                BrandId = 1,
                Price = faker.Random.Decimal(0, 10),
                Discount = faker.Finance.Amount(10, 1000),
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            };

            builder.HasData(product1,product2,product3);
        }
    }
}
