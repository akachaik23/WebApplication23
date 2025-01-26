using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories;

public interface IProductRepository
{
    bool DeleteProduct(int id);
    List<Product> GetProduct(int id);
    List<Product> GetProducts();
    bool UpdateProduct(int id);
}
