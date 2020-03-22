using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blog");
            modelBuilder.Entity<Blog>().HasKey(c => c.Id);
            modelBuilder.Entity<Blog>().Property(c => c.Title).HasMaxLength(2000).IsRequired().IsUnicode(false);
            modelBuilder.Entity<Blog>().Property(c => c.CreationDate).HasColumnType("datetime2(3)");
            modelBuilder.Entity<Blog>()
                .HasMany(c => c.Posts)
                .WithOne(c => c.Blog)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Blog>()
                .HasOne(c => c.Author)
                .WithMany(c => c.Blogs)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Post>().HasKey(c => c.Id);
            modelBuilder.Entity<Post>()
                .Property(c => c.Title)
                .HasMaxLength(2000)
                .IsRequired()
                .IsUnicode(false);
            modelBuilder.Entity<Post>()
                .Property(c => c.Body)
                .HasColumnType("varchar(max)")
                .IsRequired()
                .IsUnicode(false);
            modelBuilder.Entity<Post>()
                .Property(c => c.PublishDate)
                .HasColumnType("datetime2(3)");
            modelBuilder.Entity<Post>()
                .HasOne(c => c.NextPost)
                .WithOne(c => c.PrevPost)
                .HasForeignKey<Post>(c => c.PrevPostId)
                .HasConstraintName("FK_Post__Post_PrevPostId")
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>()
                .HasOne(c => c.PrevPost)
                .WithOne(c => c.NextPost)
                .HasForeignKey<Post>(c => c.NextPostId)
                .HasConstraintName("FK_Post__Post_NextPostId")
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .HasConstraintName("FK_Post__PostComment_PostId")
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PostComment>().ToTable("PostComment");
            modelBuilder.Entity<PostComment>().HasKey(c => c.Id);
            modelBuilder.Entity<PostComment>()
                .Property(c => c.CreationDate)
                .HasColumnType("datetime2(3)");
            modelBuilder.Entity<PostComment>()
                .Property(c => c.Body)
                .HasColumnType("varchar(max)")
                .IsRequired()
                .IsUnicode(false);
            modelBuilder.Entity<PostComment>()
                .HasOne(c => c.Author)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.UserId)
                .HasConstraintName("FK_PostComment__User_UserId")
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PostComment>()
                .HasOne(c => c.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.PostId)
                .HasConstraintName("FK_PostComment__Post_PostId")
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PostComment>()
                .HasMany(c => c.Comments)
                .WithOne(c => c.ParentComment)
                .HasForeignKey(c => c.ParentCommentId)
                .HasConstraintName("FK_PostComment__PostComment_ParentCommentId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(c => c.Id);
            modelBuilder.Entity<User>()
                .Property(c => c.FirstName)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();
            modelBuilder.Entity<User>()
                .Property(c => c.MiddleName)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();
            modelBuilder.Entity<User>()
                .Property(c => c.LastName)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode();
        }
    }
}
