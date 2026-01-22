
namespace Catalog.API.Products.DeleteProduct;
using Models;

internal record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
internal record DeleteProductResult(bool Deleted);
internal class DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);
        return new DeleteProductResult(true);
    }
}

