using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reports.API.Models
{
    public class Person
    {
        [Key] 
        public string Id { get; set; }

        [Required] 
        public string Name { get; set; }
    }
    
    public class Employer : Person
    {
        public virtual Supervisor Supervisor { get; set; }
    }
    
    public class Supervisor : Employer
    {
        public List<Employer>? Employers { get; set; }
    }
}