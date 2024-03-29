using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.UnitOfWorks;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommandRequest>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateProductsCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateProductsCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });

                    await unitOfWork.SaveAsync();
                }
            }
        }
    }
}
