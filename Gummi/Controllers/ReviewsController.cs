using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gummi.Models;

namespace Gummi.Controllers
{
  public class ReviewsController : Controller
  {
        
    private GummiDbContext db = new GummiDbContext();
    public IActionResult Index()
    {
      return View(db.Reviews.Include(items => items.Product).ToList());
    }

    public IActionResult Details(int id)
    {
      var thisReview = db.Reviews.FirstOrDefault(items => items.ReviewId == id);
      return View(thisReview);
    }

    public IActionResult Create()
    {
      ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
      return View();
    }

    [HttpPost]
    public IActionResult Create(Review item)
    {
      db.Reviews.Add(item);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var thisReview = db.Reviews.FirstOrDefault(items => items.ReviewId == id);
      ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
      return View(thisReview);
    }
    [HttpPost]
    public IActionResult Edit(Review item)
    {
      db.Entry(item).State = EntityState.Modified;
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisReview = db.Reviews.FirstOrDefault(items => items.ReviewId == id);
      return View(thisReview);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      var thisReview = db.Reviews.FirstOrDefault(items => items.ReviewId == id);
      db.Reviews.Remove(thisReview);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
