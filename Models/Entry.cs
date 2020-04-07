using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GitFit.Models
{
    public class Entry
    {
        [Key]
        public int EntryId { get; set; }
        [Required]
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public List <Activity> Activity { get; set; }
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
