using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class SubjectDb
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdFacultity { get; set; }

    public int IdPhoto { get; set; }

    public decimal Price { get; set; }

    public virtual Faculty IdFacultityNavigation { get; set; } = null!;

    public virtual Photo IdPhotoNavigation { get; set; } = null!;

    public virtual ICollection<SubjectPackage> SubjectPackages { get; set; } = new List<SubjectPackage>();
}
