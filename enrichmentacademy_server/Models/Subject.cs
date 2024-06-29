using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdFaculty { get; set; }

    public decimal Price { get; set; }

    public int IdPhoto { get; set; }

    public virtual Photo IdPhotoNavigation { get; set; } = null!;

    public virtual ICollection<LessonSubject> LessonSubjects { get; set; } = new List<LessonSubject>();

    public virtual ICollection<SubjectPackage> SubjectPackages { get; set; } = new List<SubjectPackage>();
}
