using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.ViewComponents
{
    public class ListCategory : ViewComponent
    {
        private readonly BlogContext _context;

        public ListCategory(BlogContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.ToListAsync();

            return View(categories);
        }
    }
}
