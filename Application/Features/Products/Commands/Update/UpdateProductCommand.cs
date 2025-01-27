using Application.Features.Products.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Update;


public class UpdateProductQuery : IRequest<bool>
{
    public UpdateProductDto UpdateProductDto { get; set; } = new UpdateProductDto();
}

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
public class UpdateProductHandler : IRequestHandler<UpdateProductQuery, bool>
{
    private readonly IProductRepository _productRepository;
    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public Task<bool> Handle(UpdateProductQuery request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = request.UpdateProductDto.Id,
            Name = request.UpdateProductDto.Name,
            Description = request.UpdateProductDto.Description
        };

        _productRepository.UpdateProduct(product);

        return Task.FromResult(true);
    }
}
