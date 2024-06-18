using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Faculty")]
[Index("Name", Name = "Faculty_name", IsUnique = true)]
public partial class Faculty
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdFacultyNavigation")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
