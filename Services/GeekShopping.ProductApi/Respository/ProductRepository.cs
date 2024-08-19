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
        return _mapper.Map<ProductVO>(product);
    }

    public async Task<ProductVO> Create(ProductVO vo)
    {
        var productMapped = _mapper.Map<Product>(vo);
        await _context.Products.AddAsync(productMapped);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductVO>(productMapped);
    }

    public async Task<ProductVO> Update(ProductVO vo)
    {
        var productMapped = _mapper.Map<Product>(vo);
        var product = _context.Products.Update(productMapped);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductVO>(productMapped);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (System.Exception)
        {

            return false;
        }
    }


}