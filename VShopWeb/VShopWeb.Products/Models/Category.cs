using System.Text.Json.Serialization;
using VShopWeb.Products.DTOs;

namespace VShopWeb.Products.Models;

public class Category
{
    public Category(string description, string name)
    {
        Id = Guid.NewGuid().ToString();
        Description = description;
        Name = name;
    }
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    
    public ICollection<Product>? Products { get; set; }
}
