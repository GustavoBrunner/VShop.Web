using Microsoft.EntityFrameworkCore;
using VShopWeb.Products.Infra;
using VShopWeb.Products.Models;
using VShopWeb.Products.Repository.Contracts;

namespace VShopWeb.Products.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApiDbContext _context;

    public CategoryRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task Create(Category category)
    {
        var result = await _context.AddAsync(category);
    }

    public async Task Delete(string id)
    {
        var entity = await Get(id);
        _context.Remove(entity);
    }
    public async Task Update(Category category)
    {
        var entity = await Get(category.Id);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<Category> Get(string id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories
            .ToListAsync();
    }

    public async Task<IEnumerable<Category>> GetAllWithProducts()
    {
        return await _context.Categories
            .Include(c => c.Products)
            .ToListAsync();
    }

    
}
