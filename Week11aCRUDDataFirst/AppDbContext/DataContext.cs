using Microsoft.EntityFrameworkCore;
using Week11aCRUDDataFirst.Models;

namespace Week11aCRUDDataFirst.AppDbContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employee { get; set; }       // Table Name
    }
}
