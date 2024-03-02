using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureProject.Domain.Entities.Models;

namespace FutureProject.Infrastructure.Persistance
{
    public class FutureProjectDbContext:DbContext
    {
        public FutureProjectDbContext(DbContextOptions<FutureProjectDbContext> options):base(options)
        {
            Database.Migrate();
        }

       

        public DbSet<User> Users { get; set; }
    }
}
