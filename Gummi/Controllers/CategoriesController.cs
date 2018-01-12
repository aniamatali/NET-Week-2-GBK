using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gummi.Models;

namespace Gummi.Controllers
{
	public class CategoriesController : Controller
	{
		private GummiDbContext db = new GummiDbContext();
		public IActionResult Index()
		{
			return View(db.Categories.ToList());
		}


        public IActionResult Details(int id)
        {
            var thisCategory = db.Categories
                                 .Include(x => x.Reviews)
                                 .FirstOrDefault(items => items.CategoryId == id);

            return View(thisCategory);
        }


		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category item)
		{
			db.Categories.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var thisCategory = db.Categories.FirstOrDefault(items => items.CategoryId == id);
			return View(thisCategory);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			db.Entry(category).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var thisCategory = db.Categories.FirstOrDefault(items => items.CategoryId == id);
			return View(thisCategory);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisCategory = db.Categories.FirstOrDefault(items => items.CategoryId == id);
			db.Categories.Remove(thisCategory);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
