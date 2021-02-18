using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class ArhiveModel : PageModel
    {
		private readonly BlogContext _context;

		public List<Post> posts;

		public ArhiveModel(BlogContext context)
		{
			_context = context;
		}

		public void OnGet(int month, int year)
        {
			posts = _context.Posts.Where(x=>x.Date.Month == month && x.Date.Year == year).ToList();
			

        }
    }
}
