using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public string? InnerException { get; set; }
        public string? StackTrace { get; set; }
        public bool ThrewException { get; set; } = default!;

        [Required]
        public DateTime DateOfEvent { get; set; }
    }
}
