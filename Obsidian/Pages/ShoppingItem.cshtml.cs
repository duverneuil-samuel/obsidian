using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Obsidian.Extensions;
using Obsidian.Models;
using Microsoft.EntityFrameworkCore;


namespace Obsidian.Pages
{
    public class ShoppingModel : PageModel
    {
        private readonly AppDbContext _context;

        public ShoppingModel(AppDbContext context)
        {
            _context = context;
        }
        public List<ShoppingItem> Panier { get; set; } = new();
        public decimal Total { get; set; }
        public void OnGet(int? userId)
        {
            if (userId.HasValue)
            {
                var orderLines = _context.OrderLines
                                         .Include(ol => ol.Offer)
                                         .ThenInclude(o => o.Product)
                                         .Include(ol => ol.Order)
                                         .Where(ol => ol.Order.BuyerId == userId && ol.Order.Status == "Cart")
                                         .ToList();

                Panier = orderLines.Select(ol => new ShoppingItem
                {
                    ProductName = ol.Offer.Product.Name,
                    Seller = ol.Offer.Seller.Name,
                    Condition = ol.Offer.Condition,
                    Language = ol.Offer.Language,
                    Price = ol.UnitPrice,
                    Quantity = ol.Quantity
                }).ToList();

                Total = Panier.Sum(i => i.Quantity * i.Price);
            }
        }


        public IActionResult OnPostUpdateQuantite(int Index, int Quantite)
        {
            var panier = HttpContext.Session.GetObject<List<ShoppingItem>>("Panier") ?? new List<ShoppingItem>();

            if (Index >= 0 && Index < panier.Count)
            {
                panier[Index].Quantity = Quantite;
            }

            HttpContext.Session.SetObject("Panier", panier);
            return RedirectToPage();
        }

        public IActionResult OnPostSupprimer(int Index)
        {
            var panier = HttpContext.Session.GetObject<List<ShoppingItem>>("Panier") ?? new List<ShoppingItem>();

            if (Index >= 0 && Index < panier.Count)
            {
                panier.RemoveAt(Index);
            }

            HttpContext.Session.SetObject("Panier", panier);
            return RedirectToPage();
        }
    }
}
