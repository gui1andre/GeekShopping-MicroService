using GeekShopping.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Controllers.Context;

class MySqlContext : DbContext
{
    public MySqlContext() { }
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}