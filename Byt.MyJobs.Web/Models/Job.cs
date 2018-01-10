using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Byt.MyJobs.Web.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsDone { get; set; }
    }
}
