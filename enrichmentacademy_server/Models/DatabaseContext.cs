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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI-VTNQ;Database=EnrichmentAcademy;user id=sa;password=123;trusted_connection=true;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Account_PK");
        });

        modelBuilder.Entity<AccountCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Account_Course_PK");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.AccountCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Account_Course_Account_FK");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.AccountCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Account_Course_Course_FK");
        });

        modelBuilder.Entity<AccountPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Account_Package_PK");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.AccountPackages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Account_Package_Account_FK");

            entity.HasOne(d => d.IdPackageNavigation).WithMany(p => p.AccountPackages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Account_Package_Package_FK");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Course_PK");
        });

        modelBuilder.Entity<CourseSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Course_Package_PK");

            entity.HasOne(d => d.IdCourseNavigation).WithMany(p => p.CourseSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Course_Package_Course_FK");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.CourseSubjects).HasConstraintName("Course_Package_Subject_FK");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Faculty_PK");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Lession_PK");
        });

        modelBuilder.Entity<LessonSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Lesson_Subject_PK");

            entity.HasOne(d => d.IdLessonNavigation).WithMany(p => p.LessonSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lesson_Subject_Lesson_FK");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.LessonSubjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Lesson_Subject_Subject_FK");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Package_PK");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Photo_PK");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Rating_PK");

            entity.HasOne(d => d.IdAccountNavigation).WithMany(p => p.Ratings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Rating_Account_FK");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Subject_PK");

            entity.HasOne(d => d.IdFacultyNavigation).WithMany(p => p.Subjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Subject_Faculty_FK");

            entity.HasOne(d => d.IdPhotoNavigation).WithMany(p => p.Subjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Subject_Photo_FK");
        });

        modelBuilder.Entity<SubjectPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Subject_Package_PK");

            entity.HasOne(d => d.IdPackageNavigation).WithMany(p => p.SubjectPackages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Subject_Package_Package_FK");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.SubjectPackages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Subject_Package_Subject_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
