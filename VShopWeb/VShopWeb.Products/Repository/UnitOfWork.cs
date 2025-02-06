using VShopWeb.Products.Infra;
using VShopWeb.Products.Repository.Contracts;

namespace VShopWeb.Products.Repository;

public class UnitOfWork : IUnityOfWork
{
    public UnitOfWork(ICategoryRepository categoryRepository, ApiDbContext apiDbContext)
    {
        CategoryRepository = categoryRepository;
        this.apiDbContext = apiDbContext;
    }
    
    private readonly ApiDbContext apiDbContext;
    private bool _disposed = false;

    public IProductRepository ProductRepository { get; private set ; }
    public ICategoryRepository CategoryRepository { get; private set; }

    public async Task<bool> Commit()
    {
        return await apiDbContext.SaveChangesAsync() > 0;
    }
    protected virtual void Dispose(bool disposing) 
    {
        if(_disposed) return;
        if (disposing)
        {
            apiDbContext.Dispose();
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
