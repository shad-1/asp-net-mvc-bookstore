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

        public IBookstoreRepository Repository { get; set; }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel(IBookstoreRepository repo, Cart cart)
        {
            Repository = repo;
            //what is it about the HTTPContext which disallows me from instantiating the cart here?
            Cart = cart;
            
        }

        public void OnGet(string _returnUrl) //this param name needs to match what will be in the URL, else it will always come back "/". 
        {
            ReturnUrl = _returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string ReturnUrl)
        {
            var book = Repository.BooksData
                .FirstOrDefault(book => book.BookId == bookId);

            Cart.AddItem(book, 1);

            return RedirectToPage( new { ReturnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string ReturnUrl)
        {
            Cart.RemoveItem(Cart.Books.First(l => l.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl });
        }
    }
}