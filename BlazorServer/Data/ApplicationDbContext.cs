using BlazorServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // tables here
        public DbSet<BlogPost> BlogPosts { get; set; } = default!;
        public DbSet<Log> Logs { get; set; } = default!;
    }
}