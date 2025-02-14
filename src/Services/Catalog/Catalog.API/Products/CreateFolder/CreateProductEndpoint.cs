using Carter;

namespace Catalog.API.Products.CreateFolder
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //we need a mapper to change request (carter) object to command(mediatr) object , thats why install nuget package Mapster in building blocks
            throw new NotImplementedException();
        }
    }
}
