using CRUD_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
        public DbSet<Person> Persons { get; set; }
    }
}