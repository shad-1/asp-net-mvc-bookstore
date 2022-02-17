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
        IBookstoreRepository _repository;

        public HomeController(IBookstoreRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(int _page = 1)
        {
            //@todo: Arbitrarily set, consider taking user input to set the perpage amount
            const int BooksPerPage = 10;
            
            var books = new BookListViewModel
            {
                BookList = _repository.BooksData
                .OrderBy(book => book.Title)
                .Skip((_page -1) * BooksPerPage)
                .Take(BooksPerPage),

                PageInfo = new PageInfo
                {
                    Items = _repository.BooksData.Count(),
                    PerPage = BooksPerPage,
                    CurrentPage = _page
                }
            };

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

