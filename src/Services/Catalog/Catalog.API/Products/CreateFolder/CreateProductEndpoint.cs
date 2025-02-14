//removed name spaces as added globalUsing file

namespace Catalog.API.Products.CreateFolder
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //we need a mapper to change request (carter) object to command(mediatr) object , thats why install nuget package Mapster in building blocks
            app.MapPost("/products",
                async (CreateProductRequest request, ISender sender) =>
                {
                    //Adapt(mapping method) wasnt being recognised here so I downgraded Mapster version to 7.0.0
                    
                    var command = request.Adapt<CreateProductCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<CreateProductResponse>();
                    return Results.Created($"/products/{response.Id}", response);
                })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
        }
    }
}
