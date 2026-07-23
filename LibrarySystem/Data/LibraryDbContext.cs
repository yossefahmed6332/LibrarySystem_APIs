using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace LibrarySystem.Data
{
    public class LibraryDbContext:IdentityDbContext<User,IdentityRole<int>,int>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }
        //create DbSet for each entity
        public virtual DbSet <Author> TbAuthors { get; set; }
        public virtual DbSet<Book> TbBooks { get; set; }
        public virtual DbSet<BookCopy> TbBooksCopies { get; set; }
        public virtual DbSet<Category> TbCategories { get; set; }
        public virtual DbSet<Address> TbAddresses { get; set; }
        public virtual DbSet<Customer> TbCustomers { get; set; }
        public virtual DbSet<Employee> TbEmployees { get; set; }
        public virtual DbSet<Operation> TbOperations { get; set; }




    }
}
