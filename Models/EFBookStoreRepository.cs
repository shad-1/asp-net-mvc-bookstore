using System;
using System.Linq;

namespace bookstore.Models
{
	public class EFBookstoreRepository : IBookstoreRepository
	{
		private BookstoreContext _context;

		public EFBookstoreRepository(BookstoreContext context)
		{
			_context = context;
		}

        public IQueryable<Books> BooksData
        {
            get
            {
                return _context.Books;
            }
        }
    }
}

