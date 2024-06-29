using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string Link { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Doc { get; set; } = null!;
}
