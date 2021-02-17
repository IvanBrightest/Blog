using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Areas.Admin.Pages.Post
{
    public class EditModel : PageModel
    {
        private readonly BlogContext _context;
        [BindProperty]
        public Models.Post BindPost { get; set; }

        [BindProperty]
        public List<Models.Category> Categories { get; set; }

        [BindProperty]
        public List<Models.Post> Posts { get; set; }

        public EditModel(BlogContext context)
        {
            _context = context;
        }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                Posts = _context.Posts.ToList();
            }
            else
            {
                BindPost = _context.Posts.FirstOrDefault(p => p.Id == id);
                Categories = _context.Categories.ToList();
            }
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var edit_Post = _context.Posts.FirstOrDefault(p => p.Id == id);

                    if (edit_Post!=null)
                    {
                        edit_Post.Title = BindPost.Title;
                        edit_Post.Description = BindPost.Description;
                        edit_Post.Text = BindPost.Text;
                        edit_Post.Author = BindPost.Author;
                        edit_Post.Category_id = BindPost.Category_id;
                        edit_Post.Secret = BindPost.Secret;

                        //_context.Posts.Update(edit_Post);
                        await _context.SaveChangesAsync();
                    }
                    

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
