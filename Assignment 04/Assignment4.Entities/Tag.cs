using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Entities
{
    public class Tag
    {
        public int Id {get; set;}

        [Required]
        [StringLength(50)]
        public string Name {get; set;}//needs to be set as uniquei in modelbuilder too

        public ICollection<Task> Tasks{get; set;}
    }
}
