using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Subject_Package")]
public partial class SubjectPackage
{
    [Key]
    public int Id { get; set; }

    public int IdSubject { get; set; }

    public int IdPackage { get; set; }

    [ForeignKey("IdPackage")]
    [InverseProperty("SubjectPackages")]
    public virtual Package IdPackageNavigation { get; set; } = null!;

    [ForeignKey("IdSubject")]
    [InverseProperty("SubjectPackages")]
    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}
