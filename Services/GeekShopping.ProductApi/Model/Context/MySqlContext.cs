using GeekShopping.ProductApi.Models;
using GeekShopping.ProductApi.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Controllers.Context;

public class MySqlContext : DbContext
{
    public MySqlContext() { }
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}