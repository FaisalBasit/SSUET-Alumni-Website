using Microsoft.EntityFrameworkCore;
using Login.Models;

namespace Login.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public virtual DbSet<UserTbl> UserTbls { get; set; }
        public virtual DbSet<AlumniGroup> AlumniGroups { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Database connection string or any other configuration should go here
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTbl>(entity =>
            {
                // Use RollNum as the primary key
                entity.HasKey(e => e.RollNum).HasName("PK_user_tbl_rollnum");

                entity.ToTable("user_tbl");

                // Define unique index on email
                entity.HasIndex(e => e.Email, "UQ_user_tbl_email").IsUnique();

                entity.Property(e => e.RollNum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("roll_num");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Gender)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.YearOfGraduation).HasColumnName("year_of_graduation");
                entity.Property(e => e.BatchNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("batch_number");
                entity.Property(e => e.LinkedInId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("linkedin_id");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<AlumniGroup>(entity =>
            {
                entity.HasKey(e => e.G_Id).HasName("PK_alumni_group_Gid");

                entity.ToTable("alumni_group");

                entity.Property(e => e.G_Id).HasColumnName("G_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Description)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => e.UserGroupId).HasName("PK_user_group");

                entity.ToTable("user_group");

                entity.Property(e => e.UserGroupId).HasColumnName("user_group_id");
                entity.Property(e => e.UserRoll).HasColumnName("user_roll");
                entity.Property(e => e.GroupId).HasColumnName("group_id");

                // Define relationships
                entity.HasOne(ug => ug.UserTbl)
                    .WithMany(u => u.UserGroups)
                    .HasForeignKey(ug => ug.UserRoll)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ug => ug.AlumniGroup)
                    .WithMany()
                    .HasForeignKey(ug => ug.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
