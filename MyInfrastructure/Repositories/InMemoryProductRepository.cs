using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInfrastructure.Repositories;

public class InMemoryProductRepository : IProductRepository
{
    public List<Product> GetProducts()
    {
        var products = new List<Product> {  
            new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200.0 },
            new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 300.0 },
            new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 400.0 },
            new Product { Id = 5, Name = "Product 5", Description = "Description 5", Price = 500.0 }
        };

        return products;
    }
}
