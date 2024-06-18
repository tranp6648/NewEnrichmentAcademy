using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Account")]
[Index("Name", Name = "Account_Name", IsUnique = true)]
[Index("Phone", Name = "Account_Phone", IsUnique = true)]
[Index("Email", Name = "Account_email", IsUnique = true)]
public partial class Account
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    public DateOnly? BirthDay { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Phone { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Password { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? AccountType { get; set; }

    [Column("OTP")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Otp { get; set; }

    [InverseProperty("IdAccountNavigation")]
    public virtual ICollection<AccountCourse> AccountCourses { get; set; } = new List<AccountCourse>();

    [InverseProperty("IdAccountNavigation")]
    public virtual ICollection<AccountPackage> AccountPackages { get; set; } = new List<AccountPackage>();

    [InverseProperty("IdAccountNavigation")]
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
