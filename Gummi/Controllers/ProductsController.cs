using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gummi.Models;

namespace Gummi.Controllers
{
	public class ProductsController : Controller
	{
        private IProductRepository productRepo;  // New!

        public ProductsController(IProductRepository repo = null)
        {
            if (repo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = repo;
            }
        }

		public IActionResult Index()
		{
            return View(productRepo.Products.Include(x=>x.Reviews).ToList());
		}

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var thisProduct = productRepo.Products
                                 .Include(x => x.Reviews)
                                 .FirstOrDefault(items => items.ProductId == id);
            return View(thisProduct);
        }

		[HttpPost]
		public IActionResult Create(Product product)
		{
            productRepo.Save(product);   // Updated
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }

		public IActionResult Edit(int id)
		{
            // Updated:
            Product thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

		[HttpPost]
		public IActionResult Edit(Product product)
		{
            productRepo.Edit(product);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }

		public IActionResult Delete(int id)
		{
            Product thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            return View(thisProduct);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Updated:
            Product thisProduct = productRepo.Products.FirstOrDefault(x => x.ProductId == id);
            productRepo.Remove(thisProduct);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }
    }
}
