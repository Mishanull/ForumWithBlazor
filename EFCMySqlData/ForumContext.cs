using Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCPostgresData;

public class ForumContext : DbContext

{
    public DbSet<Post> Post { get; set; }
    public DbSet<User> User { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=Forum;username=root;password=12345",new MySqlServerVersion(new Version(8,0,28)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<Post>().HasKey(post => post.Id);
        modelBuilder.Entity<Comment>().HasKey(comment => comment.Id);
    }
}