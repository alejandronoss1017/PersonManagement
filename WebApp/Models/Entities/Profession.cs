using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entities;

[Table("Profession")]
public partial class Profession
{
    [Key]
    public int Id { get; set; }

    [StringLength(90)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(256)]
    [Unicode(false)]
    public string? Description { get; set; }

    [InverseProperty("IdProfessionNavigation")]
    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();
}
