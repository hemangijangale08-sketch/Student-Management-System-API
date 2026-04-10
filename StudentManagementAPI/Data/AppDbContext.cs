using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;
using System.Collections.Generic;


namespace StudentManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
