using Microsoft.EntityFrameworkCore;

namespace piktureAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = Environment.GetEnvironmentVariable("CLEARDB_DATABASE_URL");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=containers-us-west-191.railway.app;Port=5718;Database=railway;Uid=root;Pwd=JJ7E8fdgLYkKhupWzG85;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
