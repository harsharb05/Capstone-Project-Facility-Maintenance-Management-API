using FacilityMaintenanceMngAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FacilityMaintenanceMngAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Facility> Facilities => Set<Facility>();
        public DbSet<Technician> Technicians => Set<Technician>();
        public DbSet<MaintenanceRequest> MaintenanceRequests => Set<MaintenanceRequest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Facility 
            modelBuilder.Entity<MaintenanceRequest>()
                .HasOne(r => r.Facility)
                .WithMany(f => f.MaintenanceRequests)
                .HasForeignKey(r => r.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);

            // Technician 
            modelBuilder.Entity<MaintenanceRequest>()
                .HasOne(r => r.Technician)
                .WithMany(t => t.AssignedRequests)
                .HasForeignKey(r => r.TechnicianId)
                .OnDelete(DeleteBehavior.SetNull);

         
            modelBuilder.Entity<MaintenanceRequest>()
                .Property(r => r.Status)
                .HasConversion<string>();

           
            modelBuilder.Entity<MaintenanceRequest>()
                .HasIndex(r => r.FacilityId);

            modelBuilder.Entity<MaintenanceRequest>()
                .HasIndex(r => r.TechnicianId);

            modelBuilder.Entity<MaintenanceRequest>()
                .HasIndex(r => r.Status);
        }
    }
}
