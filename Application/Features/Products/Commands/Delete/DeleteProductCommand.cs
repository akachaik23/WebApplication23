using Application.Features.Products.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Delete
{

    public class DeleteProductQuery : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductQuery, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<bool> Handle(DeleteProductQuery request, CancellationToken cancellationToken)
        {
            bool result = _productRepository.DeleteProduct(request.Id);
            return Task.FromResult(true);
        }
    }
}
