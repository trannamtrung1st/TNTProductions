using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestDataService.Models
{
    public partial class FushariContext : DbContext
    {
        public FushariContext()
        {
        }

        public FushariContext(DbContextOptions<FushariContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Interactive> Interactive { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<TagsOfPost> TagsOfPost { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=FushariEx; Trusted_Connection = True;User Id=123456;Password=Models;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => new { e.OfUserId, e.ToPostId })
                    .HasName("PK_Answer_1");

                entity.Property(e => e.PostedTime).HasColumnType("datetime");

                entity.Property(e => e.TextContent).HasColumnType("text");

                entity.HasOne(d => d.OfUser)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.OfUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_AppUser");

                entity.HasOne(d => d.ToPost)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.ToPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Post");
            });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("IX_AppUser")
                    .IsUnique();

                entity.Property(e => e.DoB).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.PostedTime).HasColumnType("datetime");

                entity.Property(e => e.TextContent).HasMaxLength(250);

                entity.HasOne(d => d.OfUser)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.OfUserId)
                    .HasConstraintName("FK_Comment_AppUser");

                entity.HasOne(d => d.ToPost)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ToPostId)
                    .HasConstraintName("FK_Comment_Post");
            });

            modelBuilder.Entity<Interactive>(entity =>
            {
                entity.Property(e => e.HappenedTime).HasColumnType("datetime");

                entity.HasOne(d => d.OfUser)
                    .WithMany(p => p.Interactive)
                    .HasForeignKey(d => d.OfUserId)
                    .HasConstraintName("FK_Interactive_AppUser");

                entity.HasOne(d => d.ToComment)
                    .WithMany(p => p.Interactive)
                    .HasForeignKey(d => d.ToCommentId)
                    .HasConstraintName("FK_Interactive_Comment");

                entity.HasOne(d => d.ToPost)
                    .WithMany(p => p.Interactive)
                    .HasForeignKey(d => d.ToPostId)
                    .HasConstraintName("FK_Interactive_Post");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostedTime).HasColumnType("datetime");

                entity.Property(e => e.TextContent).HasColumnType("text");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.OfUser)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.OfUserId)
                    .HasConstraintName("FK_Post_AppUser");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.TagCode).HasMaxLength(50);
            });

            modelBuilder.Entity<TagsOfPost>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId });

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TagsOfPost)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagsOfPost_Post");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagsOfPost)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagsOfPost_Tags");
            });
        }
    }
}
