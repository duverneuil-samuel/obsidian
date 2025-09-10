public class Offer
{
    public int Id { get; set; }
    public int ProductId  { get; set; }
    public int SellerId { get; set; }
    public decimal Price { get; set; }
    public string Language { get; set; }
    public string Condition { get; set; }
    public int Quantity { get; set; }

    public Product  Product  { get; set; }
    public User Seller { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
