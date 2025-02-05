namespace VShopWeb.Products.Repository.Contracts;

public interface IUnityOfWork : IDisposable
{
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public Task<bool> Commit();
    public void Dispose();
}
