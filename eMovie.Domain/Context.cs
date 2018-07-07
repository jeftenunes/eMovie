using eMovie.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMovie.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("emovie");
        }

        private void ConfigureMovies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>((e) =>
            {
                e.ToTable("movie");
                e.HasKey(m => m.Id).HasName("id");


                e.Property(m => m.CreatedAt).HasColumnName("createdat");
                e.Property(m => m.CreatedAt).HasColumnName("updatedat");
                e.Property(m => m.Title).HasColumnName("title").HasMaxLength(1000);
                e.Property(m => m.Id).HasColumnName("id").ValueGeneratedOnAdd();
                e.Property(m => m.Url).HasColumnName("url").HasMaxLength(int.MaxValue);
                e.Property(m => m.Url).HasColumnName("url").HasMaxLength(int.MaxValue);
                e.Property(m => m.Description).HasColumnName("description").HasMaxLength(1000);
                e.Property(m => m.Duration).HasColumnName("duration").HasMaxLength(int.MaxValue);
            });
        }

        private void ConfigureUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>((e) =>
            {
                e.ToTable("user");
                e.HasKey(m => m.Id).HasName("id");

                e.Property(m => m.CreatedAt).HasColumnName("createdat");
                e.Property(m => m.CreatedAt).HasColumnName("updatedat");
                e.Property(m => m.Id).HasColumnName("id").ValueGeneratedOnAdd();
                e.Property(m => m.Email).HasColumnName("email").HasMaxLength(100);
                e.Property(m => m.UserName).HasColumnName("username").HasMaxLength(100);
                e.Property(m => m.Password).HasColumnName("password").HasMaxLength(int.MaxValue);
            });
        }
    }
}
