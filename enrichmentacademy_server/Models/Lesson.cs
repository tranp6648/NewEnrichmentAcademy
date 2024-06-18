using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Lesson")]
[Index("Name", Name = "Lesson_name", IsUnique = true)]
public partial class Lesson
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Link { get; set; } = null!;

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Document { get; set; } = null!;

    [InverseProperty("IdLessonNavigation")]
    public virtual ICollection<LessonSubject> LessonSubjects { get; set; } = new List<LessonSubject>();
}
