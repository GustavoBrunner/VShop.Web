namespace VShopWeb.Products.Models;

public class Product
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public long Stock { get; set; }

    public Category? Category { get; set; }

}
