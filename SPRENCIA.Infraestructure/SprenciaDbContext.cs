using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure
{
    public class SprenciaDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JOSE_MANUEL_M\\SQLEXPRESS; User Id=sa; Password=sql1234maria; Database=SprenciaDb; Trusted_Connection=True; Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

    
}
