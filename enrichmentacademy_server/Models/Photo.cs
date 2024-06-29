using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Photo
{
    public int Id { get; set; }

    public string Link { get; set; } = null!;

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
