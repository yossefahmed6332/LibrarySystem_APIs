using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Size { get; set; } = null!; 
        public int Pages { get; set; }
        public string ISBN { get; set; } = null!; 
     

        public DateTime PublishDate { get; set; }
        public string Publisher { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string Description { get; set; } = null!; 

        // Relation to Author
        public int AuthorId { get; set; }
     
        public Author Author { get; set; } = null!;

        // Relation to Category
     
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // A book can have multiple physical copies
        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
