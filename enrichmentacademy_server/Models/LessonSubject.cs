using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class LessonSubject
{
    public int Id { get; set; }

    public int IdSubject { get; set; }

    public int IdPackage { get; set; }

    public virtual Package IdPackageNavigation { get; set; } = null!;
}
