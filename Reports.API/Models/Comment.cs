using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reports.API.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Required]
        public string EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
        
        [Required]
        public string TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}