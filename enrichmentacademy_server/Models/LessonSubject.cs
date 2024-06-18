using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Lesson_Subject")]
public partial class LessonSubject
{
    [Key]
    public int Id { get; set; }

    public int IdSubject { get; set; }

    public int IdLesson { get; set; }

    [ForeignKey("IdLesson")]
    [InverseProperty("LessonSubjects")]
    public virtual Lesson IdLessonNavigation { get; set; } = null!;

    [ForeignKey("IdSubject")]
    [InverseProperty("LessonSubjects")]
    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}
