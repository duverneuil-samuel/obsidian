using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProductModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public decimal? MaxPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Language { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Condition { get; set; }

    public List<Offre> OffresFiltrees { get; set; }

    public string ProductName { get; set; } = "Nom du produit";
    public string ImageUrl { get; set; } = "/images/example.jpg";

    public void OnGet()
    {// Exemple a remplacer par bdd
        var toutesLesOffres = new List<Offre>
        {
            new Offre { Seller = "MaxCard", Pays = "🇫🇷", Condition = "Bon", Language = "Français", Price = 10.00m, Quantity = 3 },
            new Offre { Seller = "CardPower", Pays = "🇧🇪", Condition = "Comme neuf", Language = "Anglais", Price = 12.00m, Quantity = 1 },
            new Offre { Seller = "MegaCartes", Pays = "🇨🇭", Condition = "Neuf", Language = "Français", Price = 15.00m, Quantity = 5 },
                    new Offre { Seller = "NeoCartes", Pays = "🇫🇷", Condition = "Bon", Language = "Français", Price = 12.00m, Quantity = 2 },
        new Offre { Seller = "CardDealer", Pays = "🇧🇪", Condition = "Neuf", Language = "Anglais", Price = 15.00m, Quantity = 1 },
        new Offre { Seller = "SuperCartes", Pays = "🇨🇭", Condition = "Comme neuf", Language = "Français", Price = 10.50m, Quantity = 3 },
        };

        OffresFiltrees = toutesLesOffres;

        if (MaxPrice.HasValue)
            OffresFiltrees = OffresFiltrees.Where(o => o.Price <= MaxPrice.Value).ToList();

        if (!string.IsNullOrWhiteSpace(Language))
            OffresFiltrees = OffresFiltrees.Where(o => o.Language == Language).ToList();

        if (!string.IsNullOrWhiteSpace(Condition))
            OffresFiltrees = OffresFiltrees.Where(o => o.Condition == Condition).ToList();
    }

    public class Offre
    {
        public string Seller { get; set; }
        public string Pays { get; set; }
        public string Condition { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
