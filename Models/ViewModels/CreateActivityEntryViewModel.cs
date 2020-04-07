using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitFit.Models.ViewModels
{
    public class ActivityEntryViewModel
    {
        public List<Entry> Entry{get; set;}
        public List<Activity> Activity { get; set; }


    }
}
