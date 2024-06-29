using System;
using System.Collections.Generic;

namespace EnrichmentAcademy.Models;

public partial class AccountPackage
{
    public int Id { get; set; }

    public int IdAccount { get; set; }

    public int IdPackage { get; set; }

    public virtual Account IdNavigation { get; set; } = null!;

    public virtual Package IdPackageNavigation { get; set; } = null!;
}
