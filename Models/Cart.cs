using System;
using System.Collections.Generic;
using System.Linq;

namespace bookstore.Models
{
	public class Cart
	{
		public Cart()
		{
		}

        public List<LineItem> Books { get; set; } = new List<LineItem>(); //instantiate outside of ctor? Should it be static?

        public void AddItem (Books book, int qty)
        {
            LineItem item = Books
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (item == null)
            {
                Books.Add(
                    new LineItem
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

        public decimal GetSum()
        {
            return Books.Sum(book => book.Qty * (decimal) book.Book.Price);
        }
    }

	public class LineItem
    {
        public int LineItemId { get; set; }
        public int Qty { get; set; }
        public Books Book { get; set; }
    }
}

