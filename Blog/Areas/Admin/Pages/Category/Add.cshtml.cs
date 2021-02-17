using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Areas.Admin.Pages.Category
{
    public class AddModel : PageModel
    {
        private readonly BlogContext _context;

        [BindProperty]
        public Models.Category Category { get; set; }

        public AddModel(BlogContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(Category);
                await _context.SaveChangesAsync();
				TempData["result"] = "Категория успешно добавлена";
                return RedirectToPage("../Index");
            }
            return Page();
        }

    }
}
