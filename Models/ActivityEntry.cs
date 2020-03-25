using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitFit.Models
{
    public class ActivityEntry
    {
        [key]
        public int id { get; set; }

        [Required]
        public int activityId { get; set; }

        [Required]
        public int entryId { get; set; }

    }
}
