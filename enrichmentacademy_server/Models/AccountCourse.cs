using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class AccountCourse
{
    public int Id { get; set; }

    public int IdAccount { get; set; }

    public int IdCourse { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual Account IdAccountNavigation { get; set; } = null!;

    public virtual Course IdCourseNavigation { get; set; } = null!;
}
