using System;
using System.Linq;

namespace bookstore.Models
{
	public interface IBookstoreRepository
	{
		IQueryable<Book> BooksData { get; }
		IQueryable<Transaction> Transactions { get; }
		void SaveTransaction(Transaction t);

		void SaveBook(Book b);
		void CreateBook(Book b);
		void DeleteBook(Book b);
	}
}

