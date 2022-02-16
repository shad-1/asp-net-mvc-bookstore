using System;
namespace bookstore.Models.ViewModels
{
	public class PageInfo
	{
		public int Items { get; set; }
        public int PerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling((float)Items / PerPage);
            }
        }
    }
}

