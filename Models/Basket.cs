using System;
using System.Collections.Generic;
using System.Linq;

namespace bookstore.Models
{
	public class Basket
	{
		public Basket()
		{
		}

        public List<BasketLineItem> Books { get; set; } = new List<BasketLineItem>(); //instantiate outside of ctor? Should it be static?

        public void AddItem (Books book, int qty)
        {
            BasketLineItem item = Books
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (item == null)
            {
                Books.Add(
                    new BasketLineItem
                    {
                        Book = book,
                        Qty = qty
                    }
                );
            }
            else
            {
                item.Qty += qty;
            }
        }
    }

	public class BasketLineItem
    {
        public int LineItemId { get; set; }
        public int Qty { get; set; }
        public Books Book { get; set; }
    }
}

