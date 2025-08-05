using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string? Task { get; set; }
        
        public bool IsDone { get; set; }
    }
}