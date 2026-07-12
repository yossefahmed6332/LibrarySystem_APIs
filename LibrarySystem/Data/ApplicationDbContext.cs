using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
namespace LibrarySystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
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
