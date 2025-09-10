using Microsoft.AspNetCore.Mvc.RazorPages;
using Obsidian.Models; 

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Obsidian.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Obsidian.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly AppDbContext _context;

        public CategoryModel(AppDbContext context)
        {
            _context = context;
        }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public int CategoryId { get; set; }

        // public void OnGet(int? categoryId)
        // {
        //     if (categoryId.HasValue)
        //     {
        //         CategoryId = categoryId.Value;

        //         var category = _context.Categories
        //                                .FirstOrDefault(c => c.Id == CategoryId);

        //         if (category != null)
        //         {
        //             CategoryName = category.Name;
        //             CategoryDescription = category.Description;

        //             Products = _context.Products
        //                                .Where(p => p.CategoryId == CategoryId)
        //                                .ToList();
        //         }
        //     }
        // }
           public async Task OnGetAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            var category = await _context.Categories
                                         .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            if (category != null)
            {
                CategoryName = category.Name;
                CategoryDescription = category.Description;

                Products = await _context.Products
                                         .Where(p => p.CategoryId == category.Id)
                                         .ToListAsync();
            }
        }
    }

}