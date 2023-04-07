﻿using Microsoft.EntityFrameworkCore;

namespace piktureAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=pikturedb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
