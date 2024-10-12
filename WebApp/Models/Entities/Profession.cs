using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities;

public class Profession
{
    [Key]
    public int Id { get; set; }
    [MaxLength(90)]
    public required string Name { get; set; }
    [MaxLength(256)]
    public string? Description { get; set; }
}