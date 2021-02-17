using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Areas.Admin.Pages.Post
{
    public class AddModel : PageModel
    {
        private readonly BlogContext _context;
        [BindProperty]
        public Models.Post BindPost { get; set; }

        [BindProperty]
        public List<Models.Category> Categories { get; set; }

        public AddModel(BlogContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Models.Post post = new Models.Post
                    {
                        Title = BindPost.Title,
                        Description = BindPost.Description,
                        Text = BindPost.Text,
                        Author = BindPost.Author,
                        Category_id = BindPost.Category_id,
                        Secret = BindPost.Secret
                    };
                    await _context.Posts.AddAsync(post);
                    await _context.SaveChangesAsync();
                    
                }
                catch (Exception)
                {

                }
                return RedirectToPage("../Index");
            }
            return RedirectToPage("../Index");
        }
    }
}
