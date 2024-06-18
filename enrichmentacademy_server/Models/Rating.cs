using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EnrichmentAcademy.Models;

[Table("Rating")]
public partial class Rating
{
    [Key]
    public int Id { get; set; }

    public int IdAccount { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string IdCourse { get; set; } = null!;

    [ForeignKey("IdAccount")]
    [InverseProperty("Ratings")]
    public virtual Account IdAccountNavigation { get; set; } = null!;
}
