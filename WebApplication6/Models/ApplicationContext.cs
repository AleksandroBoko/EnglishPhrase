using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Phrase> Phrases { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        }
    }
}
