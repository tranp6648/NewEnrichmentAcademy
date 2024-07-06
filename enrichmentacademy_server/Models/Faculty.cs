using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SubjectDb> SubjectDbs { get; set; } = new List<SubjectDb>();
}
