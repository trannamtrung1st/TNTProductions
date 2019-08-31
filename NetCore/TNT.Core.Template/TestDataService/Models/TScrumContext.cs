using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestDataService.Models
{
    public partial class TScrumContext : DbContext
    {
        public TScrumContext()
        {
        }

        public TScrumContext(DbContextOptions<TScrumContext> options)
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
        public virtual DbSet<Epics> Epics { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sprints> Sprints { get; set; }
        public virtual DbSet<TaskActivities> TaskActivities { get; set; }
        public virtual DbSet<TaskAttachments> TaskAttachments { get; set; }
        public virtual DbSet<TaskChecklistItems> TaskChecklistItems { get; set; }
        public virtual DbSet<TaskChecklists> TaskChecklists { get; set; }
        public virtual DbSet<TaskMembers> TaskMembers { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<UserStories> UserStories { get; set; }
        public virtual DbSet<UserStoryAcceptanceCriterias> UserStoryAcceptanceCriterias { get; set; }
        public virtual DbSet<UserStoryRequirements> UserStoryRequirements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=TScrumDev; Trusted_Connection = False;User Id=sa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(100);

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

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId).HasMaxLength(100);

                entity.Property(e => e.RoleId).HasMaxLength(100);

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

                entity.Property(e => e.UserId).HasMaxLength(100);

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

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Epics>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AsA).HasMaxLength(100);

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.FinishedDate).HasColumnType("datetime");

                entity.Property(e => e.Iwant).HasColumnName("IWant");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Epics)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Epics_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Sprints>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.FinishedTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PlanningEndTime).HasColumnType("datetime");

                entity.Property(e => e.PlanningStartTime).HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SprintGoal).HasMaxLength(255);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Sprints)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Sprints_Products");
            });

            modelBuilder.Entity<TaskActivities>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TaskId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskActivities)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskActivities_Tasks");
            });

            modelBuilder.Entity<TaskAttachments>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Url).IsUnicode(false);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TaskAttachments)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskAttachments_TaskActivities");
            });

            modelBuilder.Entity<TaskChecklistItems>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ChecklistId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Checklist)
                    .WithMany(p => p.TaskChecklistItems)
                    .HasForeignKey(d => d.ChecklistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskChecklistItems_TaskChecklists");
            });

            modelBuilder.Entity<TaskChecklists>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.TaskId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskChecklists)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_TaskChecklists_Tasks");
            });

            modelBuilder.Entity<TaskMembers>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TaskId });

                entity.Property(e => e.UserId).HasMaxLength(100);

                entity.Property(e => e.TaskId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskMembers)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskMembers_Tasks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TaskMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaskMembers_AspNetUsers");
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DueTime).HasColumnType("datetime");

                entity.Property(e => e.FinishedTime).HasColumnType("datetime");

                entity.Property(e => e.SprintId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.StoryId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tags).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Sprint)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.SprintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_Sprints");

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasks_UserStories");
            });

            modelBuilder.Entity<UserStories>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AsA).HasMaxLength(100);

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.EpicId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FinishedDate).HasColumnType("datetime");

                entity.Property(e => e.Iwant).HasColumnName("IWant");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SprintId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Epic)
                    .WithMany(p => p.UserStories)
                    .HasForeignKey(d => d.EpicId)
                    .HasConstraintName("FK_UserStories_Epics");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserStories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Backlogs_Products");
            });

            modelBuilder.Entity<UserStoryAcceptanceCriterias>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.GivenStatement).HasMaxLength(255);

                entity.Property(e => e.StoryId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ThenStatement).HasMaxLength(255);

                entity.Property(e => e.WhenStatement).HasMaxLength(255);

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.UserStoryAcceptanceCriterias)
                    .HasForeignKey(d => d.StoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserStoryAcceptanceCriterias_UserStories");
            });

            modelBuilder.Entity<UserStoryRequirements>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.StoryId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Story)
                    .WithMany(p => p.UserStoryRequirements)
                    .HasForeignKey(d => d.StoryId)
                    .HasConstraintName("FK_UserStoryRequirements_UserStories");
            });
        }
    }
}
