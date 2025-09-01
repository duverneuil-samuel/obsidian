using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Obsidian.Models;
public class ShoppingModel : PageModel
{
    public List<ShoppingItem> Panier { get; set; } = new();

    public void OnGet()
    {// Exemple a remplacé par bdd
        if (TempData["Panier"] is List<ShoppingItem> tempPanier)
        {
            Panier = tempPanier;
        }
    }

    public IActionResult OnPostUpdateQuantite(int Index, int Quantite)
    {
        if (TempData["Panier"] is List<ShoppingItem> panier)
        {
            panier[Index].Quantity = Quantite;
            TempData["Panier"] = panier;
        }
        return RedirectToPage();
    }

    public IActionResult OnPostSupprimer(int Index)
    {
        if (TempData["Panier"] is List<ShoppingItem> panier)
        {
            panier.RemoveAt(Index);
            TempData["Panier"] = panier;
        }
        return RedirectToPage();
    }
}
