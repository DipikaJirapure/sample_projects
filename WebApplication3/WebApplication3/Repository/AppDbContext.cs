using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Example table
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<UserModel>(entity =>
        //    {
        //        entity.ToTable("Users");

        //        entity.HasKey(u => u.Id);

        //        entity.Property(u => u.Email)
        //            .IsRequired();

        //        entity.HasIndex(u => u.Email)
        //            .IsUnique();
        //    });
        //}
    }
}
