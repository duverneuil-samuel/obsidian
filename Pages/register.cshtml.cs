using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Obsidian.Models;

public class RegisterModel : PageModel
{
    //private readonly AppDbContext _context;
    public RegisterModel(/*AppDbContext context*/)
    {
         // a remetre quan don aura bien relier la db
       // _context = context;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        [Display(Name = "Nom d'utilisateur")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // a remetre quan don aura bien relier la db
        // var user = new User
        // {
        //     Name = Input.Username,
        //     Email = Input.Email,
        //     PasswordHash = Input.Password
        // };

        // _context.Users.Add(user);
        // _context.SaveChanges();

        return RedirectToPage("/Index");
    }
}
