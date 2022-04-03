using System;
using System.Linq;

namespace bookstore.Models
{
	public interface IBookstoreRepository
	{
		IQueryable<Books> BooksData { get; }
		IQueryable<Transaction> Transactions { get; }
		void SaveTransaction(Transaction t);
	}
}

