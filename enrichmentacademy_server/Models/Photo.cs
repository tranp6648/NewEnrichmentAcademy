using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Photo
{
    public int Id { get; set; }

    public string Link { get; set; } = null!;

    public virtual ICollection<SubjectDb> SubjectDbs { get; set; } = new List<SubjectDb>();
}
