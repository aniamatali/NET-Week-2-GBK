using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using World_Travel_Blog.Models;

namespace World_Travel_Blog.Controllers
{
    public class ExperiencesController : Controller
    {
        private WorldTravelDbContext db = new WorldTravelDbContext();
        public IActionResult Index()
        {
            return View(db.Experiences.Include(items => items.Location).ToList());
        }
        public IActionResult Details(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(items => items.ExperienceId == id);
            return View(thisExperience);
        }
        public IActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Experience item)
        {
            db.Experiences.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(items => items.ExperienceId == id);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name");
            return View(thisExperience);
        }
        [HttpPost]
        public IActionResult Edit(Experience item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(items => items.ExperienceId == id);
            return View(thisExperience);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisExperience = db.Experiences.FirstOrDefault(items => items.ExperienceId == id);
            db.Experiences.Remove(thisExperience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}