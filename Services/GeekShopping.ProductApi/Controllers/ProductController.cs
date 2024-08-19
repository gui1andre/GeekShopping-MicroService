using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id) 
    {
        var product = await _repository.FindById(id);
        if(product == null) return NotFound();

        return Ok(product);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductVO>>> GetAll()
    {
        var products = await _repository.FindAll();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductVO productVO) 
    {
        return Ok(await _repository.Create(productVO));
    }
    [HttpPut]
    public async Task<IActionResult> Update(ProductVO productVO) 
    {
        var product = await _repository.Update(productVO);
        return Ok(product);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(long id) 
    {
        var status = await _repository.Delete(id);

        if (!status) return BadRequest();

        return Ok();
    }

}
