namespace VShopWeb.Products.Models;

public class Product
{
    public Product()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public long Stock { get; set; }

    public Category? Category { get; set; }
    public string CategoryId { get; set; } = string.Empty;

}
