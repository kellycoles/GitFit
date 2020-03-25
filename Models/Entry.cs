using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitFit.Models
{
    public class Entry
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime date { get; set; }

        public string notes { get; set; }

        [Required]
        public int userId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
