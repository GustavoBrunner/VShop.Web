namespace VShopWeb.Products.Repository.Contracts;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public Task<bool> Commit();
    public void Dispose();
}
