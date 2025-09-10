public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public string StockStatus { get; set; } = "InStock";
    public string StockText = "Disponible"; 
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<Offer> Offers { get; set; } = new List<Offer>();
}