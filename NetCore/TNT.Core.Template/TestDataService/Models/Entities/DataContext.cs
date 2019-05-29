using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestDataService.Models.Entities
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<VisionAndScopeDocs> VisionAndScopeDocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=EzReq; Trusted_Connection = False;User Id=sa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.Property(e => e.Code)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Detail).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).HasMaxLength(450);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasIndex(e => new { e.Code, e.OrganizationId })
                    .HasName("IX_Projects")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Organizations");
            });

            modelBuilder.Entity<VisionAndScopeDocs>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.Major, e.Minor });

                entity.Property(e => e.Background).HasColumnType("text");

                entity.Property(e => e.BusinessAssumptionsAndDependencies).HasColumnType("text");

                entity.Property(e => e.BusinessContext).HasColumnType("text");

                entity.Property(e => e.BusinessObjectives).HasColumnType("text");

                entity.Property(e => e.BusinessOpportunity).HasColumnType("text");

                entity.Property(e => e.BusinessRequirements).HasColumnType("text");

                entity.Property(e => e.BusinessRisks).HasColumnType("text");

                entity.Property(e => e.ChangeName).HasMaxLength(255);

                entity.Property(e => e.ChangeReason).HasColumnType("text");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeploymentConsiderations).HasColumnType("text");

                entity.Property(e => e.LimitationsAndExclusions).HasColumnType("text");

                entity.Property(e => e.MajorFeatures).HasColumnType("text");

                entity.Property(e => e.ProjectPriorities).HasColumnType("text");

                entity.Property(e => e.ScopeAndLimitations).HasColumnType("text");

                entity.Property(e => e.ScopeOfInitialRelease).HasColumnType("text");

                entity.Property(e => e.ScopeOfSubsequentReleases).HasColumnType("text");

                entity.Property(e => e.StakeHolderProfiles).HasColumnType("text");

                entity.Property(e => e.SuccessMetrics).HasColumnType("text");

                entity.Property(e => e.VisionStatements).HasColumnType("text");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.VisionAndScopeDocs)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisionAndScopeDocs_Projects");
            });
        }
    }
}
