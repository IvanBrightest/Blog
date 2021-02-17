using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class EditModel : PageModel
    {
		private readonly BlogContext _db;

		[BindProperty]
		public Category Category { get; set; }

		public List<Category> categories;

		public EditModel(BlogContext db)
		{
			_db = db;
		}

		public async Task OnGetAsync(int? id)
        {
			if(id == null)
			{
				categories = await _db.Categories.ToListAsync();
			}
			else
			{
				Category = await _db.Categories.FindAsync(id);
				if (Category == null) NotFound();
			}
        }

		public async Task<IActionResult> OnPostAsync(int id)
		{
			if(ModelState.IsValid)
			{
				try
				{
					var c_edit = await _db.Categories.FindAsync(id);
					if (c_edit == null) return NotFound();

					c_edit.Title = Category.Title; 

					await _db.SaveChangesAsync();

					return RedirectToPage("../Index");

				}
				catch (Exception)
				{
				}
			}
			return RedirectToPage("Edit", new { id = id });
		}
    }
}
