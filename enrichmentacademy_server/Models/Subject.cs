using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Subject")]
[Index("Name", Name = "Subject_Name", IsUnique = true)]
public partial class Subject
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int IdFaculty { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public int IdPhoto { get; set; }

    [InverseProperty("IdSubjectNavigation")]
    public virtual ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();

    [ForeignKey("IdFaculty")]
    [InverseProperty("Subjects")]
    public virtual Faculty IdFacultyNavigation { get; set; } = null!;

    [ForeignKey("IdPhoto")]
    [InverseProperty("Subjects")]
    public virtual Photo IdPhotoNavigation { get; set; } = null!;

    [InverseProperty("IdSubjectNavigation")]
    public virtual ICollection<LessonSubject> LessonSubjects { get; set; } = new List<LessonSubject>();

    [InverseProperty("IdSubjectNavigation")]
    public virtual ICollection<SubjectPackage> SubjectPackages { get; set; } = new List<SubjectPackage>();
}
