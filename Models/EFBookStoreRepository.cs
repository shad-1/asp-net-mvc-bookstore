using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Models
{
	public class EFBookstoreRepository : IBookstoreRepository
	{
		private BookstoreContext _context;

		public EFBookstoreRepository(BookstoreContext context)
		{
			_context = context;
		}

        public IQueryable<Book> BooksData
        {
            get
            {
                return _context.Books;
            }
        }

        public IQueryable<Transaction> Transactions => _context.Transactions.Include(transaction => transaction.LineItems).ThenInclude(item => item.Book);

        public void TrySaveContext()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void SaveTransaction(Transaction t)
        {
            _context.AttachRange(t.LineItems.Select(item => item.Book));

            if (t.ID == 0)
                _context.Transactions.Add(t);
            TrySaveContext();
        }

        public void SaveBook(Book b)
        {
            TrySaveContext();
        }

        public void CreateBook(Book b)
        {
            _context.Books.Add(b);
            TrySaveContext();
        }

        public void DeleteBook(Book b)
        {
            _context.Books.Remove(b);
            TrySaveContext();
        }
    }
}

