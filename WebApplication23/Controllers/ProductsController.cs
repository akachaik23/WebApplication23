using Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication23.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // Create
    [HttpPost]
    public IActionResult CreateProduct()
    {
        return Ok();
    }

    // read  single prouct
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        return Ok();
    }

    // Read
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    // Update
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id)
    {
        return Ok();
    }

    // Delete
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        return Ok();
    }
}
