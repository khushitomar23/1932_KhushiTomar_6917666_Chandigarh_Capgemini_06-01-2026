using Microsoft.EntityFrameworkCore;
using HealthcareShared.Models;

namespace HealthcareShared.Data
{
    public class HealthcareDbContext : DbContext
    {
        public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Doctor (1-1)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId);

            // Department - Doctor (1-M)
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Department)
                .WithMany(d => d.Doctors)
                .HasForeignKey(d => d.DepartmentId);

            // Appointment - Patient (1-M)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.PatientId);

            // Appointment - Doctor (1-M)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            // Appointment - Prescription (1-1)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithOne(a => a.Prescription)
                .HasForeignKey<Prescription>(p => p.AppointmentId);

            // Appointment - Bill (1-1)
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Appointment)
                .WithOne(a => a.Bill)
                .HasForeignKey<Bill>(b => b.AppointmentId);

            // Add seed data
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Cardiology", Description = "Heart and cardiovascular diseases" },
                new Department { DepartmentId = 2, DepartmentName = "Neurology", Description = "Brain and nervous system disorders" },
                new Department { DepartmentId = 3, DepartmentName = "Orthopedics", Description = "Bone and joint disorders" },
                new Department { DepartmentId = 4, DepartmentName = "Dermatology", Description = "Skin disorders" }
            );
        }
    }
}
