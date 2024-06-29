using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Rating
{
    public int Id { get; set; }

    public int IdAccount { get; set; }

    public int IdCourse { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;
}
