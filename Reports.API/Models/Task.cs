using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reports.API.Models
{
    public class Task
    {
        [Key]
        public string Id { get; set; }
        
        [Required]
        public string EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
        
        [Required]
        public TaskStatus Status { get; set; } = TaskStatus.Open;
        
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public DateTime LastUpdateAt { get; set; } = DateTime.Now;
        
        public string? Description { get; set; }
        
        public virtual ICollection<Comment>? Comments { get; set; }
    }

    public enum TaskStatus
    {
        Open, Active, Resolved,
    }
}