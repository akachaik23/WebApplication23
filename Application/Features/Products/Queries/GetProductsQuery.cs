using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries;

// pattern:  cqrs Comamand Query Responsibility Segregation
// library : MediatR
public class GetProductsQuery : IRequest<List<Product>>
{
    //public int Id { get; set; }
}


public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;
    public GetProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _productRepository.GetProducts();
        return Task.FromResult(products);
    }
}
