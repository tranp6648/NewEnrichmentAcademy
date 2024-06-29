using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AccountCourse> AccountCourses { get; set; } = new List<AccountCourse>();

    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
}
