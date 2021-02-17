using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blog.Pages.Post
{
    public class DetailModel : PageModel
    {
		private readonly BlogContext _context;

		public Models.Post GetPost { get; set; }

		public DetailModel(BlogContext context)
		{
			_context = context;
		}
        public async Task OnGet(int id)
        {
			if (id <= 0)
			{
				RedirectToPage("Index");
			}

			GetPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
			ViewData["Title"] = GetPost.Title;
			
			if (GetPost == null)
			{
				RedirectToPage("Index");
			}
        }
    }
}
