using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DemoWebRazor.Data;
using DemoWebRazor.Models;

namespace DemoWebRazor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            context.Categories.Add(Category);
            context.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
