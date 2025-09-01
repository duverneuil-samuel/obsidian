public class Order
{
    public int Id { get; set; }
    public int BuyerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal? Total { get; set; }
    public User Buyer { get; set; }
    public ICollection<OrderLine> OrderLines { get; set; }
}
