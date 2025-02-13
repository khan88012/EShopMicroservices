﻿using MediatR;

namespace Catalog.API.Products.CreateFolder
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        :IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);


    internal class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //business logic to create a product
            throw new NotImplementedException();
        }
    }
}
