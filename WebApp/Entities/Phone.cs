using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Entities;

[Table("Phone")]
public partial class Phone
{
    [Key]
    [StringLength(15)]
    [Unicode(false)]
    public string Number { get; set; } = null!;

    [StringLength(45)]
    [Unicode(false)]
    public string Carrier { get; set; } = null!;

    public int Owner { get; set; }

    [ForeignKey("Owner")]
    [InverseProperty("Phones")]
    public virtual Person OwnerNavigation { get; set; } = null!;
}
