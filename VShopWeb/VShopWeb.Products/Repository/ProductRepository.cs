using Microsoft.EntityFrameworkCore;
using VShopWeb.Products.Infra;
using VShopWeb.Products.Models;
using VShopWeb.Products.Repository.Contracts;

namespace VShopWeb.Products.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApiDbContext _context;

    public ProductRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task Create(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task Delete(Product product)
    {
        var entity = await GetById(product.Id);
        _context.Entry(entity).State = EntityState.Deleted;
    }


    public async Task Update(Product product)
    {
        var entity = await GetById(product.Id);
        _context.Entry(entity).State = EntityState.Modified;
    }
    public async Task<Product> GetById(string id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);    
    }


    public async Task<IEnumerable<Product>> GetAllWithCategory()
    {
        return await _context.Products
            .Include(p => p.Category)
            .ToListAsync();
    }

}
