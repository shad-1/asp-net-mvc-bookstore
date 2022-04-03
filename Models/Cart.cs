using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace bookstore.Models
{
    public class Cart
	{
		public Cart()
		{
		}

        public List<LineItem> Books { get; set; } = new List<LineItem>();

        public virtual void AddItem (Books book, int qty)
        {
            LineItem currentItem = Books
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if (currentItem == null)
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
                currentItem.Qty += qty;
            }
        }

        public virtual void DecrementQty (Books book)
        {
            LineItem currentItem = Books
                .Where(l => l.Book.BookId == book.BookId)
                .FirstOrDefault();

            currentItem.Qty -= 1;

            if (currentItem.Qty < 1)
            {
                RemoveItem(book);
            }
        }

        public virtual void RemoveItem (Books book)
        {
            Books.RemoveAll(l => l.Book.BookId == book.BookId);
        }

        public virtual void ClearCart ()
        {
            Books.Clear();
        }

        public decimal GetSum()
        {
            return Books.Sum(book => book.Qty * (decimal) book.Book.Price);
        }
    }

	public class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        public int Qty { get; set; }
        public Books Book { get; set; }
    }
}

