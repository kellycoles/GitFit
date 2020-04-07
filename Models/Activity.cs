using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitFit.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        [Display(Name = "Activity")]
        public string Type { get; set; }

        [Required]
        public int Duration { get; set; }

        [Display(Name = "Intensity Level")]
        public string Intensity { get; set; }

        [Required]
        public int EntryId { get; set; }
        public Entry Entry { get; set; }
        public List <Entry> Entries { get; set;}
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
