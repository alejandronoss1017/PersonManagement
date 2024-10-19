using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entities;

[PrimaryKey("IdProfession", "IdPerson")]
[Table("Education")]
public partial class Education
{
    [Key]
    public int IdProfession { get; set; }

    [Key]
    public int IdPerson { get; set; }

    public DateOnly? Date { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? University { get; set; }

    [ForeignKey("IdPerson")]
    [InverseProperty("Educations")]
    public virtual Person IdPersonNavigation { get; set; } = null!;

    [ForeignKey("IdProfession")]
    [InverseProperty("Educations")]
    public virtual Profession IdProfessionNavigation { get; set; } = null!;
}
