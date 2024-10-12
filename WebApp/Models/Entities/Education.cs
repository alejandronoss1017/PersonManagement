using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities;

public class Education
{
        public required int IdProfession { get; set; }
        public required int IdPerson { get; set; }
        public DateTime? Date { get; set; }
        [MaxLength(50)]
        public string? University { get; set; }
        
        public Person? Person { get; set; }
        public Profession? Profession { get; set; }
}