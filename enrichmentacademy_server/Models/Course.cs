using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Course")]
[Index("Name", Name = "Course_name", IsUnique = true)]
public partial class Course
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdCourseNavigation")]
    public virtual ICollection<AccountCourse> AccountCourses { get; set; } = new List<AccountCourse>();

    [InverseProperty("IdCourseNavigation")]
    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
}
