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

            // this is setup in sql server and abstracted from my control (i want that here)
            modelBuilder.Entity<IdentityUser>()
            .HasMany<Comment>()
            .WithOne()
            .HasForeignKey(c => c.UserId);

            // this I am directly setting it
            modelBuilder.Entity<BlogPost>()
                .HasMany(b=>b.PostComments)
                .WithOne()
                .HasForeignKey(c => c.BlogPostId);
        }


        public DbSet<BlogPost> BlogPosts { get; set; } = default!;
        public DbSet<Log> Logs { get; set; } = default!;
        public DbSet<Subscriber> Subscribers { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; } = default!;
    }
}