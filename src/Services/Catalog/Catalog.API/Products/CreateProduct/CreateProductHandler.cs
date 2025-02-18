

namespace Catalog.API.Products.CreateFolder
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        :ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price is required");

        }
    }

        //The reason they are using the constructor "CreateProductHandler(IDocumentSession session)" directly in the class name is because of Primary Constructors, a feature introduced in C# 12.
        internal class CreateProductHandler
            (IDocumentSession session, ILogger<CreateProductHandler> logger) 
            : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("CreateProductHandler.Handle called with {@Command}", command);


            //business logic to create a product

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,

            };
            //todo save to database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

                //return CreateProductResult result
            return new CreateProductResult(product.Id);
        }
    }
}
