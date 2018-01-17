using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gummi.Models;

namespace Gummi.Controllers
{
  public class ReviewsController : Controller
  {
        private IReviewRepository reviewRepo;

     
        public ReviewsController(IReviewRepository repo = null)
        {
            if (repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        private GummiDbContext db = new GummiDbContext();
    public IActionResult Index()
    {
      return View(reviewRepo.Reviews.Include(x => x.Product).ToList());
    }

    public IActionResult Details(int id)
    {
      Review thisReview = reviewRepo.Reviews.FirstOrDefault(items => items.ReviewId == id);
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
            reviewRepo.Save(item);   // Updated
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }

    public IActionResult Edit(int id)
    {
      Review thisReview = reviewRepo.Reviews.FirstOrDefault(items => items.ReviewId == id);
      ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
      return View(thisReview);
    }
    [HttpPost]
    public IActionResult Edit(Review item)
    {
            reviewRepo.Edit(item);
      return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
      Review thisReview = reviewRepo.Reviews.FirstOrDefault(items => items.ReviewId == id);
      return View(thisReview);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      Review thisReview = reviewRepo.Reviews.FirstOrDefault(items => items.ReviewId == id);
      reviewRepo.Remove(thisReview);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
