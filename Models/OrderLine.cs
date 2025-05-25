public class OrderLine
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int OfferId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public Order Order { get; set; }
    public Offer Offer { get; set; }
}
