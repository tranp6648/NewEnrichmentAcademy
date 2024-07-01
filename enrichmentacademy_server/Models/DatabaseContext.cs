using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountCourse> AccountCourses { get; set; }

    public virtual DbSet<AccountPackage> AccountPackages { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseSubject> CourseSubjects { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonSubject> LessonSubjects { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectPackage> SubjectPackages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=LAPTOP-OARQJFR4;Database=OnlineCourse;user id=sa;password=123;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Otp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OTP");
            entity.Property(e => e.Otptime)
                .HasColumnType("datetime")
                .HasColumnName("OTPTime");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AccountCourse>(entity =>
        {
            entity.ToTable("Account_Course");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.AccountCourses)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Course_Account");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.AccountCourses)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Course_Course");
        });

        modelBuilder.Entity<AccountPackage>(entity =>
        {
            entity.ToTable("Account_Package");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.AccountPackage)
                .HasForeignKey<AccountPackage>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Package_Account");

            entity.HasOne(d => d.IdPackageNavigation).WithMany(p => p.AccountPackages)
                .HasForeignKey(d => d.IdPackage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Package_Package");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CourseSubject>(entity =>
        {
            entity.ToTable("Course_Subject");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.CourseSubjects)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Subject_Account");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.CourseSubjects)
                .HasForeignKey(d => d.IdCourse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Subject_Course");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.ToTable("Faculty");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.ToTable("Lesson");

            entity.Property(e => e.Doc)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Link)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LessonSubject>(entity =>
        {
            entity.ToTable("Lesson_Subject");

            entity.HasOne(d => d.IdPackageNavigation).WithMany(p => p.LessonSubjects)
                .HasForeignKey(d => d.IdPackage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_Subject_Package");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.LessonSubjects)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_Subject_Subject");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.ToTable("Package");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.ToTable("Photo");

            entity.Property(e => e.Link)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Rating");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.IdAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rating_Account");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdPhotoNavigation).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdPhoto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subject_Photo");
        });

        modelBuilder.Entity<SubjectPackage>(entity =>
        {
            entity.ToTable("Subject_Package");

            entity.HasOne(d => d.IdPackageNavigation).WithMany(p => p.SubjectPackages)
                .HasForeignKey(d => d.IdPackage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subject_Package_Package");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.SubjectPackages)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subject_Package_Subject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
