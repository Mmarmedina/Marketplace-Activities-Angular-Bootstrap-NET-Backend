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

            // MMM Relación N a M entre la tabla opiniones y tabla actividades.
            // MMM .OnDelete(DeleteBehavior.Restrict). Al intentar eliminar una actividad que tenga opiniones asociadas, se generará un error y no se permitirá la eliminación de la actividad hasta que las opiniones asociadas se eliminen o la relación se modifique.
            // MMM FK:.IsRequired(false). Que en la tabla de opiniones, el campo ActivityId (FK) puede ser null (cuando la opinión sea de Sprencia no tendrá ActivityId asociado).
            modelBuilder.Entity<Review>()
              .HasOne(b => b.Activity)
              .WithMany()
              .HasForeignKey(b => b.ActivityId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Cascade);
            //.OnDelete(DeleteBehavior.Restrict);

            // MMM Relación M a M entre la tabla actividades y horarios (tabla intermedia).
            modelBuilder.Entity<ActivitiesSchedules>()
              .HasOne(sa => sa.Activity)
              .WithMany(a => a.ActivitySchedules)
              .HasForeignKey(sa => sa.ActivityId);

            modelBuilder.Entity<ActivitiesSchedules>()
              .HasOne(sa => sa.Schedule)
              .WithMany(s => s.ActivitySchedules)
              .HasForeignKey(sa => sa.ScheduleId);
        }
    }

    
}
