using System;
using System.Linq;

namespace bookstore.Models.ViewModels
{	
	/**
	* Informaiton needed for a page listing all the books in a collection
	*/
	public class BookListViewModel
	{
		public IQueryable<Books> BookList { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}

