﻿using Library.Domain.Entities;
using Library.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Book>()
                .HasAlternateKey(b => b.ISBN);

            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN)
                .HasMaxLength(17);
            
            modelBuilder.Entity<Book>()
                .HasOne<Author>(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasOne<Genre>(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .IsRequired();

            modelBuilder.Entity<Author>().HasData([
                new Author { Id=1, Name = "Stephen", Surname = "King" },
                new Author { Id=2, Name = "Chuck", Surname = "Palahniuk" },
                new Author { Id=3, Name = "Agatha", Surname = "Christie" }
                ]);

            modelBuilder.Entity<Genre>().HasData([
                new Genre { Id=1, Name = "Horror" },
                new Genre { Id=2, Name = "Detective" },
                new Genre { Id=3, Name = "Sci-fi" }
                ]);

            modelBuilder.Entity<Book>().HasData([
                new Book {Id = 1, AuthorId = 1, GenreId = 1, ISBN = "978-5-17-065495-6", Name="IT", TakeDateTime = DateTime.Now, Status = BookAvailability.Taken},
                new Book {Id = 2, AuthorId = 1, GenreId = 1, ISBN = "978-5-17-062440-3", Name="Carrie", TakeDateTime = DateTime.Now - TimeSpan.FromHours(4), Status = BookAvailability.Taken},
                new Book {Id = 3, AuthorId = 2, GenreId = 3, ISBN = "978-5-17-147507-9", Name="Fight Club", TakeDateTime = new DateTime(2023,12,16,16,48,29),ReturnDateTime = DateTime.Now, Status = BookAvailability.InStock},
                new Book {Id = 4, AuthorId = 3, GenreId = 2, ISBN = "978-5-04-099247-8", Name="Murder on the Orient Express", TakeDateTime = new DateTime(2024,01,05,12,45,37), Status = BookAvailability.Taken}
                ]);


            base.OnModelCreating(modelBuilder);
        }
    }
}