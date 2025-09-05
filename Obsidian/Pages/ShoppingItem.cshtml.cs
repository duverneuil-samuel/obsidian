using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Obsidian.Extensions;
using Obsidian.Models;
public class ShoppingModel : PageModel
{
    public List<ShoppingItem> Panier { get; set; } = new();

    public void OnGet()
    {
         Panier = HttpContext.Session.GetObject<List<ShoppingItem>>("Panier") ?? new List<ShoppingItem>();


        // Exemple a remplacé par bdd
        if (TempData["Panier"] is List<ShoppingItem> tempPanier)
        {
            Panier = tempPanier;
        }
        else
        {
            // ✅ Simulation de données factices
            Panier = new List<ShoppingItem>
        {
            new ShoppingItem { ProductName = "Clavier mécanique", Seller = "Sam", Condition = "Neuf", Language = "FR", Price = 89.99m, Quantity = 1 },
            new ShoppingItem { ProductName = "Souris gaming", Seller = "Lucie", Condition = "Occasion", Language = "EN", Price = 49.50m, Quantity = 2 },
            new ShoppingItem { ProductName = "Tapis de souris XXL", Seller = "Jean", Condition = "Neuf", Language = "FR", Price = 25m, Quantity = 1 }
        };
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

    // public IActionResult OnPostUpdateQuantite(int Index, int Quantite)
    // {
    //     if (TempData["Panier"] is List<ShoppingItem> panier)
    //     {
    //         panier[Index].Quantity = Quantite;
    //         TempData["Panier"] = panier;
    //     }
    //     return RedirectToPage();
    // }

    // public IActionResult OnPostSupprimer(int Index)
    // {
    //     if (TempData["Panier"] is List<ShoppingItem> panier)
    //     {
    //         panier.RemoveAt(Index);
    //         TempData["Panier"] = panier;
    //     }
    //     return RedirectToPage();
    // }
}
