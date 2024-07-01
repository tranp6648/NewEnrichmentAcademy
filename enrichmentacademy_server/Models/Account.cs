using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string Phone { get; set; } = null!;

    public int Accountype { get; set; }

    public string Password { get; set; } = null!;

    public string? Otp { get; set; }

    public bool IsActive { get; set; }

    public DateTime? Otptime { get; set; }

    public virtual ICollection<AccountCourse> AccountCourses { get; set; } = new List<AccountCourse>();

    public virtual AccountPackage? AccountPackage { get; set; }

    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
