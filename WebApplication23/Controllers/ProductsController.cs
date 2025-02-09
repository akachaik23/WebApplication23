using Application.Features.Products.Commands.Update;
using Application.Features.Products.Commands.Delete;
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
        var query = new GetProductQuery { Id = id };
        var product = _mediator.Send(query);
        return Ok(product);
    }

    // Read
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductQuery());
        return Ok(products);
    }

    // Update
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto product, int id)
    {
        if (product.Id != id)
        {
            return BadRequest("Invalid id");
        }

        var query = new UpdateProductQuery
        {
            UpdateProductDto = product
        };

        var result = await _mediator.Send(query);
        
        return Ok(result);
    }

    // Delete
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var query = new DeleteProductQuery { Id = id };
        var result = _mediator.Send(query);

        if (!result.Result)
        {
            return NotFound(new { message = "Product not found" });
        }

        return Ok(new { message = "Product deleted successfully" });
    }
}
