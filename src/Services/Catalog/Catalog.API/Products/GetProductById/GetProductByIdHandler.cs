
using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById;

using Microsoft.Extensions.Logging;
using Models;


internal record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
internal record GetProductByIdResult(Product Product);
internal class GetProductByIdHandler (IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null) throw new ProductNotFoundException(query.Id);

        return new GetProductByIdResult(product);
    }
}

