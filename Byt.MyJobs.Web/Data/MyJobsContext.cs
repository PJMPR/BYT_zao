using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Byt.MyJobs.Web.Models
{
    public class MyJobsContext : DbContext
    {
        public MyJobsContext (DbContextOptions<MyJobsContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Job { get; set; }
    }
}
