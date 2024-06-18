using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Course_Subject")]
public partial class CourseSubject
{
    [Key]
    public int Id { get; set; }

    public int IdCourse { get; set; }

    public int? IdSubject { get; set; }

    [ForeignKey("IdCourse")]
    [InverseProperty("CourseSubjects")]
    public virtual Course IdCourseNavigation { get; set; } = null!;

    [ForeignKey("IdSubject")]
    [InverseProperty("CourseSubjects")]
    public virtual Subject? IdSubjectNavigation { get; set; }
}
