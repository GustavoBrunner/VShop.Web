using Microsoft.EntityFrameworkCore;
using VShopWeb.Products.Models;

namespace VShopWeb.Products.Infra;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder mB)
    {
        //Products



        //Categories

    }

}
