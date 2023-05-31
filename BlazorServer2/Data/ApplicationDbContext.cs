﻿using BlazorServer2.Models;
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

        public DbSet<BlogPost> BlogPosts { get; set; } = default!;
        public DbSet<Log> Logs { get; set; } = default!;
        public DbSet<Subscriber> Subscribers { get; set; } = default!;
    }
}