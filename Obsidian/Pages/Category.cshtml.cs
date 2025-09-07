using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class CategoryModel : PageModel
{
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public List<Product> Products { get; set; }

    public void OnGet()
    {
        CategoryName = "Catégorie Exemple";
        CategoryDescription = "Description de la catégorie.";
        Products = new List<Product>
        {
            new Product { Id = 1, Name = "Produit A", Price = 19.99, ImageUrl="/images/a.png", StockStatus="in-stock", StockText="En stock" },
            new Product { Id = 2, Name = "Produit B", Price = 9.99, ImageUrl="/images/b.png", StockStatus="low-stock", StockText="Stock faible" }
        };
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
    public string StockStatus { get; set; }
    public string StockText { get; set; }
}