using Microsoft.AspNetCore.Mvc.RazorPages;
using Obsidian.Models; 

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
        public List<Product> Products { get; set; }
        public int CategoryId { get; set; }

        public void OnGet(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                CategoryId = categoryId.Value;

                var category = _context.Categories
                                       .FirstOrDefault(c => c.Id == CategoryId);

                if (category != null)
                {
                    CategoryName = category.Name;
                    CategoryDescription = category.Description;

                    Products = _context.Products
                                       .Where(p => p.CategoryId == CategoryId)
                                       .ToList();
                }
            }
        }
    }

}