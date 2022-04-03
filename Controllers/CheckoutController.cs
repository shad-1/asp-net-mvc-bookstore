using System;
using bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
	public class CheckoutController: Controller
	{
		IBookstoreRepository _repo { get; set; }
		Cart _cart { get; set; }

		public CheckoutController(IBookstoreRepository repo, Cart cart)
		{
			_repo = repo;
			_cart = cart;
		}

		[HttpGet]
		public IActionResult Checkout()
        {
			//Do not let the user checkout if their cart is empty.
			if (_cart.Books.Count == 0)
				return RedirectToPage("/Cart");
			else
				ViewBag.OrderTotal = _cart.GetSum();
				return View(new Transaction());
        }

		[HttpPost]
		public IActionResult Checkout(Transaction t)
        {
			ViewBag.OrderTotal = _cart.GetSum();

			if (ModelState.IsValid)
            {
				t.LineItems = _cart.Books;
                try
                {
					_repo.SaveTransaction(t);
					_cart.ClearCart();
				}
				catch (Exception e)
                {
					Console.WriteLine(e);
					return RedirectToPage("/Error");
                }
				
				return RedirectToPage("/Success");
			}
            else
            {
				return View(t);
            }
        }
	}
}

