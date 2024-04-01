using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductsCommandValidator : AbstractValidator<CreateProductsCommandRequest>
    {
        public CreateProductsCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Başlık");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıklama");

            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Marka");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Fiyat");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithName("İndirim Oranı");

            RuleFor(x => x.CategoryIds)
                .Must(categories => categories.Any())
                .WithName("Kategori");

        }
    }
}
