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
public class GetProductQuery : IRequest<List<Product>>
{
    public int Id { get; set; }
}


public class GetProductsHandler : IRequestHandler<GetProductQuery, List<Product>>
{
    private readonly IProductRepository _productRepository;
    public GetProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<List<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        
        int id = request.Id;
        var products = new List<Product>();
        if (id > 0)
        {
            products = _productRepository.GetProduct(id); products.Where(p => p.Id == id).ToList();
        }
        else {
            products = _productRepository.GetProducts();
        }
        return Task.FromResult(products);
    }
}
