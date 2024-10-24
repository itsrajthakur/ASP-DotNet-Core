using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DemoWebRazor.Data;
using DemoWebRazor.Models;

namespace DemoWebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            CategoryList = context.Categories.ToList(); ;
        }
    }
}
