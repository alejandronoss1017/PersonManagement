using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Entities;

[Table("Person")]
public partial class Person
{
    [Key]
    public int Id { get; set; }

    [StringLength(45)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(45)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    public int? Age { get; set; }

    [InverseProperty("IdPersonNavigation")]
    public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

    [InverseProperty("OwnerNavigation")]
    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();
}
