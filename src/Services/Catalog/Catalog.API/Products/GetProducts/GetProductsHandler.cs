
using Marten.Linq;

namespace Catalog.API.Products.GetProducts;
using Models;
using System.Threading;
using System.Threading.Tasks;

internal record GetProductsQuery() : IQuery<GetProductsResult>;
internal record GetProductsResult(IEnumerable<Product> Products);
internal class GetProductsHandler (IDocumentSession session, ILogger<GetProductsHandler> logger)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsHandler.Handle called with {@Query}", query);
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductsResult(products);
    }
}

