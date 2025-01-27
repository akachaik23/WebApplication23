using Application.Features.Products.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.Update
{

    public class UpdateProductQuery : IRequest<bool>
    {
        public int Id { get; set; }
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
            bool result = _productRepository.UpdateProduct(request.Id);
            return Task.FromResult(true);
        }
    }
}
