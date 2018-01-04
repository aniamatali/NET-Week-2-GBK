using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using World_Travel_Blog.Models;

namespace World_Travel_Blog.Controllers
{
	public class LocationsController : Controller
	{
		private WorldTravelDbContext db = new WorldTravelDbContext();
		public IActionResult Index()
		{
			return View(db.Locations.ToList());
		}


        public IActionResult Details(int id)
        {
            var thisLocation = db.Locations
                                 .Include(x => x.Experiences)
                                 .FirstOrDefault(items => items.LocationId == id);

            return View(thisLocation);
        }


		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Location item)
		{
			db.Locations.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(items => items.LocationId == id);
			return View(thisLocation);
		}
		[HttpPost]
		public IActionResult Edit(Location item)
		{
			db.Entry(item).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Delete(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(items => items.LocationId == id);
			return View(thisLocation);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(items => items.LocationId == id);
			db.Locations.Remove(thisLocation);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}