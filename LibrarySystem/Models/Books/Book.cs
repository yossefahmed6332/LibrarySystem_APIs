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
        public ICollection <Author> Authors { get; set; } = new HashSet<Author>();

        // Relation to Category
     
        public ICollection<Category> Categories { get; set; } = null!;

        // A book can have multiple physical copies
        public ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
