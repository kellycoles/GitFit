using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitFit.Models
{
    public class Biometrics
    {
        [key]
        public int id{ get; set; }

        [Display(Name = "Height")]
        public int height { get; set; }

        [Display(Name = "Weight")]
        public int weight{ get; set; }

        [Display(Name = "Age")]
        public int age { get; set; }

        [Display(Name = "Sex")]
        public string sex { get; set; }
        [Required]
        public int userId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
