using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities;

public class Phone
{
    [Key]
    [MaxLength(15)]
    public required string Number { get; set; }
    [MaxLength(45)]
    public required string Carrier { get; set; }
    public required int Owner { get; set; }

    public Person? Person { get; set; }
}