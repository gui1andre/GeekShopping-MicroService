using AutoMapper;
using GeekShopping.ProductApi.Controllers.Context;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly MySqlContext _context;
    private IMapper _mapper;

    public ProductRepository(MySqlContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductVO>> FindAll()
    {
        var products = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductVO>>(products);
    }

    public async Task<ProductVO> FindById(long id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }

    public Task<ProductVO> Create(ProductVO vo)
    {
        throw new NotImplementedException();
    }

    public Task<ProductVO> Update(ProductVO vo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(long id)
    {
        throw new NotImplementedException();
    }


}