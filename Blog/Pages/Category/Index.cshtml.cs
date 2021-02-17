using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly BlogContext _context;

        [BindProperty]
        public Models.Category Category { get; set; }

        public List<Models.Post> Posts { get; set; }
        public IndexModel(BlogContext context)
        {
            _context = context;
        }

        public async Task OnGet(int id)
        {
            Category = await _context.Categories.FirstOrDefaultAsync(cat => cat.Id == id);
			ViewData["Title"] = "Заметки категории - " + Category.Title;
            Posts = await _context.Posts.Where(c => c.Category_id == id).ToListAsync();
        }
    }
}
