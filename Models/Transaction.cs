using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace bookstore.Models
{
	public class Transaction
	{
		public Transaction()
		{
		}
		[Key]
		[BindNever]
        public int ID { get; set; }
		[BindNever]
        public ICollection<LineItem> LineItems { get; set; }

		[Required(ErrorMessage = "Enter Your Name")]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required(ErrorMessage = "Enter a Valid Address")]
		[MaxLength(100)]
		public string Address1 { get; set; }
		public string Address2 { get; set; }

		[Required(ErrorMessage = "Enter a City")]
		[MaxLength(35)]
        public string City { get; set; }

		[Required(ErrorMessage = "Enter a two-letter state abbreviation")]
		[MaxLength(2)]
		public string State { get; set; }

		[Required(ErrorMessage = "Enter a Valid Zip Code")]
		[MaxLength(10)]
		public string Zip { get; set; }

		[Required(ErrorMessage = "Enter a Valid Country")]
		[MaxLength(20)]
		public string Country { get; set; }

		public bool Gift { get; set; }

		[BindNever]
		public bool Shipped { get; set; }
    }
}

