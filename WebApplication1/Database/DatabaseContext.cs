using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
           
        }
        public DbSet<Club> club { get; set; }
        public DbSet<Player> player { get; set; }
    }
}
