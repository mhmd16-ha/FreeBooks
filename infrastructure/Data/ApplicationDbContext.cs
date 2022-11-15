using Domain.Entity;
using infrastructure.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.Data
{
   public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().Property(c => c.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<LogCategory>().Property(c => c.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<SubCategory>().Property(c => c.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<LogSubCategory>().Property(c => c.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<Book>().Property(c => c.Id).HasDefaultValueSql("(newid())");
            modelBuilder.Entity<LogBook>().Property(c => c.Id).HasDefaultValueSql("(newid())");






        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LogCategory> LogCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<LogSubCategory> LogSubCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<LogBook> LogBooks { get; set; }




    }
}
