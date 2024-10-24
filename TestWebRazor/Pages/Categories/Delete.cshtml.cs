using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DemoWebRazor.Data;
using DemoWebRazor.Models;

namespace DemoWebRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = context.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                context.Categories.Remove(Category);
                context.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
