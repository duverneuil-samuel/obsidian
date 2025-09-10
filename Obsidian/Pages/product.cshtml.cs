using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Obsidian.Models;
    public class ProductModel : PageModel
    {
          private readonly AppDbContext _context;

        public ProductModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Language { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Condition { get; set; }

        public List<Offer> OffresFiltrees { get; set; }

        public string ProductName { get; set; } = "Nom du produit";
        public string ImageUrl { get; set; } = "/images/example.jpg";

    public void OnGet()
    {
            var query = _context.Offers.AsQueryable();

            if (MaxPrice.HasValue)
                query = query.Where(o => o.Price <= MaxPrice.Value);

            if (!string.IsNullOrWhiteSpace(Language))
                query = query.Where(o => o.Language == Language);

            if (!string.IsNullOrWhiteSpace(Condition))
                query = query.Where(o => o.Condition == Condition);

            OffresFiltrees = query.ToList();
        }
    }
