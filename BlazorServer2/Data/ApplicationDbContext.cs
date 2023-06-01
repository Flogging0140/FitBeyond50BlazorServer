using BlazorServer2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // use FLUID API to have 1 identity user to many Comments
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
            .HasMany<Comment>()
            .WithOne()
            .HasForeignKey(c => c.UserId);
        }


        public DbSet<BlogPost> BlogPosts { get; set; } = default!;
        public DbSet<Log> Logs { get; set; } = default!;
        public DbSet<Subscriber> Subscribers { get; set; } = default!;
        public DbSet<Comment> Commments { get; set; } = default!;
    }
}