using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Package")]
[Index("Name", Name = "Package_name", IsUnique = true)]
public partial class Package
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdPackageNavigation")]
    public virtual ICollection<AccountPackage> AccountPackages { get; set; } = new List<AccountPackage>();

    [InverseProperty("IdPackageNavigation")]
    public virtual ICollection<SubjectPackage> SubjectPackages { get; set; } = new List<SubjectPackage>();
}
