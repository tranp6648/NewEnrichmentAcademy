using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class SubjectPackage
{
    public int Id { get; set; }

    public int IdPackage { get; set; }

    public int IdSubject { get; set; }

    public virtual Package IdPackageNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}
