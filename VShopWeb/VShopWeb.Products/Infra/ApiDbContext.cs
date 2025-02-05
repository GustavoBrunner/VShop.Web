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
        mB.Entity<Product>()
            .ToTable("product");
        mB.Entity<Product>()
            .HasKey(p => p.Id);
        mB.Entity<Product>().Property(p => p.Id)
            .HasColumnName("pk_id")
            .HasMaxLength(100);
        mB.Entity<Product>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();
        mB.Entity<Product>()
            .Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(255)
            .IsRequired();
        mB.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnName("price")
            .HasPrecision(10,2)
            .IsRequired();
        mB.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(p => p.Products);
        mB.Entity<Product>()
            .Property(p => p.CategoryId)
            .HasColumnName("fk_category_id")
            .HasMaxLength(100);

        //Categories

        mB.Entity<Category>()
            .ToTable("category");
        mB.Entity<Category>()
            .HasKey(p => p.Id);
        mB.Entity<Category>()
            .Property(p => p.Id)
            .HasColumnName("pk_id")
            .HasMaxLength(100);
        mB.Entity<Category>()
            .Property(p => p.Name)
            .HasColumnName("name")
            .HasMaxLength(100);
        mB.Entity<Category>()
            .Property(p => p.Description)
            .HasColumnName("description")
            .HasMaxLength(255);
        

    }

}
