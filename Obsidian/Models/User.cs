public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Country { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
