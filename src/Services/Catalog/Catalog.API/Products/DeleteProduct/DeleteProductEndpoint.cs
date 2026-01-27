namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductRequest(Guid Id);
public record DeleteProductResponse(bool IsSuccess);
public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{Id:guid}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id), cancellationToken);
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
        .WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Products")
        .WithDescription("Delete Products"); ;
    }
}

