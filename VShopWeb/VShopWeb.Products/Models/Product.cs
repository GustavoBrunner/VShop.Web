namespace VShopWeb.Products.Models;

public class Product
{
    public Product(string name, string description, decimal price, long stock, string imageUrl)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        ImageUrl = imageUrl;
    }
    public string Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public decimal Price { get; set; }



    public long Stock { get; set; }

    public Category? Category { get; set; }
    public string CategoryId { get; set; } = string.Empty;

}
