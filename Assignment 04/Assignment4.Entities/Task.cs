using Assignment4.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Assignment4.Entities
{
    public class Task
    {
        public int Id {get; set;}

        [Required]
        [StringLength(100)]
        public string Title {get; set;}

        [StringLength(int.MaxValue)]
        public string? Description {get; set;}

        public User? AssignedTo{get; set;}

        [Required]
        public State State{get; set;}

        public ICollection<Tag> Tags {get; set;}
    }
}
