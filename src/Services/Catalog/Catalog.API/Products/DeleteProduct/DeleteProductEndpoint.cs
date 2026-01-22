namespace Catalog.API.Products.DeleteProduct
{
    internal record DeleteProductRequest(Guid Id);
    internal record DeleteProductResponse(Guid Id);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            //app.MapDelete("/products/{Id:guid}",)
        }
    }
}
