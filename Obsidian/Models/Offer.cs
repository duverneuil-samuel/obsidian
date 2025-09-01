public class Offer
{
    public int Id { get; set; }
    public int CardId { get; set; }
    public int SellerId { get; set; }
    public decimal Price { get; set; }
    public string Language { get; set; }
    public string Condition { get; set; }
    public int Quantity { get; set; }

    public Card Card { get; set; }
    public User Seller { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}
