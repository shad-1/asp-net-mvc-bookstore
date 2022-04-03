using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bookstore.Models;
using bookstore.Models.ViewModels;

namespace bookstore.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repository;
        private Cart _cart;

        public HomeController(IBookstoreRepository repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }

        public IActionResult Index(int pageNum = 1, string category = "All")
        {
            //@todo: Arbitrarily set, consider taking user input to set the perpage amount
            const int BooksPerPage = 10;

            // Isolate filtration for use in both models
            var filteredBooks = _repository.BooksData.Where(book => book.Category == category || category.ToUpper() == "ALL");


            var books = new BookListViewModel
            {
                BookList = filteredBooks
                .OrderBy(book => book.Title)
                .Skip((pageNum -1) * BooksPerPage)
                .Take(BooksPerPage),

                PageInfo = new PageInfo
                {
                    Items = filteredBooks.Count(),
                    PerPage = BooksPerPage,
                    CurrentPage = pageNum
                }
            };

            //Selected Category for filter builder
            ViewBag.SelectedCategory = category;
            ViewBag.OrderTotal = _cart.GetSum();

            return View(books);
        }
        //* I prefer to leave developer exceptions on while I'm working on a project
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

