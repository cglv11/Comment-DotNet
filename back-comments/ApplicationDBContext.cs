using System;
using back_comments.Models;
using Microsoft.EntityFrameworkCore;

namespace back_comments
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
