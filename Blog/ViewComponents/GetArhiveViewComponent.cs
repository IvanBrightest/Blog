using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Extensions;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.ViewComponents
{
    public class GetArhiveViewComponent : ViewComponent
    {
        private readonly BlogContext _context;

		public GetArhiveViewComponent(BlogContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<GetArhiveViewModel> query_arhive = await _context.Posts.OrderByDescending(y=>y.Date)
									.Select(x => new GetArhiveViewModel
									{
										Month = x.Date.ToString("MMMM"),
										MonthNum = x.Date.Month,
										Year = x.Date.Year
									}).ToListAsync();

			var arhive = query_arhive.Distinct(new GetArhiveComparer());
			return View(arhive);
		}
	}
}