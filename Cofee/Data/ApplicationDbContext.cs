using Cofee.Models;
using Cofee.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cofee.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News => Set<News>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<User>()
                .Property(e => e.Created)
                .HasDefaultValueSql("now()");

            modelBuilder
                .Entity<News>()
                .Property(e => e.DateUpdate)
                .HasDefaultValueSql("now()");

            modelBuilder
               .Entity<News>()
               .Property(e => e.DatePublication)
               .HasDefaultValueSql("now()");

            modelBuilder
                .Entity<News>()
                .Property(e => e.CreateDate)
                .HasDefaultValueSql("now()");

            //modelBuilder
            //   .Entity<News>()
            //   .Property(e => e.DateUpdate)
            //   .HasDefaultValueSql("now()");

            modelBuilder
                .Entity<News>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);

            modelBuilder
                .Entity<News>()
                .Property(e => e.IsDelite)
                .HasDefaultValue(false);
        }


    }
}
