using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [Required]
        public long BookId { get; set; } //long because we are going to take over the market!
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [Range(1, 10000)]
        public int PageCount { get; set; }
        [Required]
        [Range(0.01, 100000)]
        public double Price { get; set; }
    }
}
