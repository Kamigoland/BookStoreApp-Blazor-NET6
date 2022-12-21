using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC0756588115");

            entity.Property(e => e.Bio)
                .HasMaxLength(250)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0766775894");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA6F324464").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "5ccb6af3-b1a7-4db0-998e-ead1bb409f78"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "98db3b50-114b-4a9a-99fd-ea57611b4b7f"
            });

        var hasher = new PasswordHasher<ApiUser>();
        modelBuilder.Entity<ApiUser>().HasData(
            new ApiUser
            {
                Id = "393a8204-b670-4dc9-a1c0-5fadcfbb4159",
                Email = "admin@bookstore.com",
                NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                UserName = "admin@bookstore.com",
                NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApiUser
            {
                Id = "5bc0a116-c932-4b95-924f-ab6c4a1f6324",
                Email = "user@bookstore.com",
                NormalizedEmail = "USER@BOOKSTORE.COM",
                UserName = "user@bookstore.com",
                NormalizedUserName = "USER@BOOKSTORE.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }) ;

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "5ccb6af3-b1a7-4db0-998e-ead1bb409f78",
                UserId = "5bc0a116-c932-4b95-924f-ab6c4a1f6324"
            },
            new IdentityUserRole<string>
            {
                RoleId = "98db3b50-114b-4a9a-99fd-ea57611b4b7f",
                UserId = "393a8204-b670-4dc9-a1c0-5fadcfbb4159"
            });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
