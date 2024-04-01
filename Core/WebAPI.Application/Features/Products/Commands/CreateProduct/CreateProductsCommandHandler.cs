using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Features.Products.Rules;
using WebAPI.Application.UnitOfWorks;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductRules productRules;

        public CreateProductsCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
        {
            this.unitOfWork = unitOfWork;
            this.productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductsCommandRequest request, CancellationToken cancellationToken)
        {

            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });

                await unitOfWork.SaveAsync();          
            }
            return Unit.Value;
        }
    }
}
