﻿using Microsoft.EntityFrameworkCore;
using myProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Data
{
    public class BlogPlatformContext : DbContext
    {
        public BlogPlatformContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>()
                .HasKey(t => new { t.PostId, t.TagId });

            modelBuilder.Entity<Post>()
               .HasMany(p => p.Comments)
               .WithOne(c => c.Post)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
