using System;
using System.Linq;
using bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Components
{
	public class CategoriesViewComponent : ViewComponent
	{
		private IBookstoreRepository _repo { get; set; }

		public CategoriesViewComponent(IBookstoreRepository repo)
		{
			_repo = repo;
		}

		public IViewComponentResult Invoke()
        {
			//Get all the distinct categories off all the books
			var categories = _repo.BooksData
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x);

			//Call the appropriate view with the list of categories as the model
			return View(categories);
        }
	}
}

