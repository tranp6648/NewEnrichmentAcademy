using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Package
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AccountPackage> AccountPackages { get; set; } = new List<AccountPackage>();

    public virtual ICollection<LessonSubject> LessonSubjects { get; set; } = new List<LessonSubject>();

    public virtual ICollection<SubjectPackage> SubjectPackages { get; set; } = new List<SubjectPackage>();
}
