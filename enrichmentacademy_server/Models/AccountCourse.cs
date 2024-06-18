using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Account_Course")]
public partial class AccountCourse
{
    [Key]
    public int Id { get; set; }

    public int IdAccount { get; set; }

    public int IdCourse { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly EndDate { get; set; }

    [ForeignKey("IdAccount")]
    [InverseProperty("AccountCourses")]
    public virtual Account IdAccountNavigation { get; set; } = null!;

    [ForeignKey("IdCourse")]
    [InverseProperty("AccountCourses")]
    public virtual Course IdCourseNavigation { get; set; } = null!;
}
