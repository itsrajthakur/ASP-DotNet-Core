using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DemoWebRazor.Data;
using DemoWebRazor.Models;

namespace DemoWebRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext context)
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
                context.Categories.Update(Category);
                context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
