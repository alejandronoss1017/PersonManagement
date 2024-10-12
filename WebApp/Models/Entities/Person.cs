using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entities;

public class Person
{
    [Key]
    public int Id { get; set; }
    [MaxLength(45)]
    public required string Name { get; set; }
    [MaxLength(45)]
    public required string LastName { get; set; }
    public required char Gender { get; set; }
    public int? Age { get; set; }
}