using CatsTagram.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CatsTagram.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> CatPosts { get; set; }
        public DbSet<Hashtag> HashTags { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hashtag>()
                .HasOne(ht => ht.Post)
                .WithMany(cp => cp.Hashtags)
                .HasForeignKey(ht => ht.CatPostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
