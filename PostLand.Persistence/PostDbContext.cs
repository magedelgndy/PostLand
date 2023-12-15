using Microsoft.EntityFrameworkCore;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Persistence
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }

        public DbSet<Post> posts { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var catId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var postId = Guid.Parse("{6313179F-7873-473A-A4D5-A5571B43E6A6}");
            modelBuilder.Entity<Category>().HasData(new Category { 
                Id = catId,
                Name = "CategoryName",
            });
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = postId,
                Title = "Title",
                Content = "hellloooo",
                ImageUrl = "wwwwwooooooooowwwwwwwwwwwwww",
                CategoryId=catId
                
            }
                );
        }
    }
}
