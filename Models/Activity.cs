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
        public int activityId { get; set; }
        [Required]
       
        [Display(Name = "Duration")]
        public int duration { get; set; }

        [Display(Name = "Intensity")]
        public string intensity { get; set; }

        [Required]
        public int userId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
