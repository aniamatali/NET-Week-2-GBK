using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gummi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gummi.Controllers
{
	public class HomeController : Controller
	{

				private GummiDbContext _db = new GummiDbContext();
        private IProductRepository productRepo;

            public HomeController(IProductRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.productRepo = new EFProductRepository();
            }
            else
            {
                this.productRepo = thisRepo;
            }
        }

        // GET: /<controller>/
        public IActionResult Index()
		{
			 List<Product> mostRecent = _db.Products.OrderByDescending(x => x.ProductId).Take(3).ToList();
				ViewData["mostRecent"] = mostRecent;
            return View();
        }

	}
}
