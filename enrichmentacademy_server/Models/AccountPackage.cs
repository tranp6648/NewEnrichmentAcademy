using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Account_Package")]
public partial class AccountPackage
{
    [Key]
    public int Id { get; set; }

    public int IdAccount { get; set; }

    public int IdPackage { get; set; }

    [ForeignKey("IdAccount")]
    [InverseProperty("AccountPackages")]
    public virtual Account IdAccountNavigation { get; set; } = null!;

    [ForeignKey("IdPackage")]
    [InverseProperty("AccountPackages")]
    public virtual Package IdPackageNavigation { get; set; } = null!;
}
