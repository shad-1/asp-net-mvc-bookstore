using System;
using System.Linq;

namespace bookstore.Models.ViewModels
{
	public class BookListViewModel
	{
		public IQueryable<Books> BookList { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}

