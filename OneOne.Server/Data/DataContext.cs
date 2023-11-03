using Microsoft.EntityFrameworkCore;
using OneOne.Shared.Entities;

namespace OneOne.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Address>? Address { get; set; }
    }
}
