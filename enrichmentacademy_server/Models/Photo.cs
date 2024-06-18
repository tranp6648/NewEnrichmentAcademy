using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Photo")]
[Index("Link", Name = "Photo_Link", IsUnique = true)]
public partial class Photo
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Link { get; set; } = null!;

    [InverseProperty("IdPhotoNavigation")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
