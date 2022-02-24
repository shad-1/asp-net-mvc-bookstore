using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bookstore.Models;
using bookstore.Infrastructure;

namespace bookstore.Pages
{
    public class CartModel : PageModel
    {

        public IBookstoreRepository _repository { get; set; }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel(IBookstoreRepository repo)
        {
            _repository = repo;
            //what is it about the HTTPContext which disallows me from instantiating the cart here? 
            
        }

        public void OnGet(string _returnUrl) //this param name needs to match what will be in the URL, else it will always come back "/". 
        {
            ReturnUrl = _returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string ReturnUrl)
        {
            var book = _repository.BooksData
                .FirstOrDefault(book => book.BookId == bookId);

            //Get the cart to manipulate
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(book, 1);

            //update the cart in the session file
            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage( new {_returnUrl = ReturnUrl});
        }
    }
}