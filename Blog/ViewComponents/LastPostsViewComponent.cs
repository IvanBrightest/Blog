using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.ViewComponents
{
    public class LastPostsViewComponent : ViewComponent
    {
        private readonly BlogContext _context;

		public LastPostsViewComponent(BlogContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync(int? take)
        {

			IEnumerable<Post> lastPosts;
			if(take == null)
			{
				lastPosts = await _context.Posts.OrderByDescending(x=>x.Date).Take(5).ToListAsync();
			}
			else
			{
				lastPosts = await _context.Posts.OrderByDescending(x=>x.Date).Take(take.GetValueOrDefault()).ToListAsync();
			}
			

            return View(lastPosts);
        }
	}
}