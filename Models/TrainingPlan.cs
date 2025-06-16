// Model, który reprezentuje dane, które będą przechowywane w tabeli bazy danych
using System.ComponentModel.DataAnnotations;

namespace TrainingPlansApi.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string? TrainingDays { get; set; }
        [Required]
        public string Exercises { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
