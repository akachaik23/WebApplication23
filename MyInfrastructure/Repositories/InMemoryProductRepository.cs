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
    private static readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100.0 },
        new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200.0 },
        new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 300.0 },
        new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 400.0 },
        new Product { Id = 5, Name = "Product 5", Description = "Description 5", Price = 500.0 }
    };

    public InMemoryProductRepository()
    {
        //Products = new List<Product> {
        //    new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 100.0 },
        //    new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 200.0 },
        //    new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 300.0 },
        //    new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 400.0 },
        //    new Product { Id = 5, Name = "Product 5", Description = "Description 5", Price = 500.0 }
        //};
    }
    public List<Product> GetProducts()
    {
        // _products.Add(new Product { Id = 6, Name = "Product 6", Description = "Description 6", Price = 600.0 });

        return _products;
    }

    public List<Product> GetProduct(int id)
    {
        var product = _products.Where(p => p.Id == id).ToList();
        return product;
    }

    public bool UpdateProduct(int id)
    {
        bool result = false;

        var product = _products.Where(p => p.Id == id).ToList();
        if (product.Count > 0)
        {
            product[0].Name = "Updated Product";
            product[0].Description = "Updated Description";
            product[0].Price = 999.99;
            result = true;
        }
        return result;
    }

    public bool DeleteProduct(int id)
    {
        bool result = false;

        var product = _products.Where(p => p.Id == id).ToList();
        if (product.Count > 0)
        {
            _products.Remove(product[0]);
            result = true;
        }

        return result;
    }

    public void UpdateProduct(Product product)
    {
        var productToUpdate = _products.Find(p => p.Id == product.Id);

        if (productToUpdate is null)
        {
            return;
        }

        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;


    }
}
