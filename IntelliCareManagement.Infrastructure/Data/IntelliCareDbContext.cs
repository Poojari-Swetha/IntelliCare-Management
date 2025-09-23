using IntelliCareManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntelliCareManagement.Infrastructure.Data
{
    public class IntelliCareDbContext : DbContext
    {
        public IntelliCareDbContext(DbContextOptions<IntelliCareDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSecurity> UserSecurities { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Role - User (One-to-Many)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID);

            // User - UserSecurity (One-to-Many)
            modelBuilder.Entity<UserSecurity>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSecurities)
                .HasForeignKey(us => us.UserID);

            // User - PatientProfile (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.PatientProfile)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.PatientID);

            // User - Doctor (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<User>(u => u.DoctorID);

            // Appointment - PatientProfile (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.PatientProfile)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID);

            // Appointment - Doctor (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorID);

            // Consultation - PatientProfile (Many-to-One)
            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.PatientProfile)
                .WithMany(p => p.Consultations)
                .HasForeignKey(c => c.PatientID);

            // Consultation - Doctor (Many-to-One)
            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Doctor)
                .WithMany(d => d.Consultations)
                .HasForeignKey(c => c.DoctorID);

            // Consultation - Appointment (Many-to-One)
            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Appointment)
                .WithMany(a => a.Consultations)
                .HasForeignKey(c => c.AppointmentID);

            // Prescription - Consultation (Many-to-One)
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Consultation)
                .WithMany(c => c.Prescriptions)
                .HasForeignKey(p => p.ConsultationID);

            // Invoice - PatientProfile (Many-to-One)
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.PatientProfile)
                .WithMany(p => p.Invoices)
                .HasForeignKey(i => i.PatientID);

            // ✅ Fix for decimal precision warning
            modelBuilder.Entity<Invoice>()
                .Property(i => i.Amount)
                .HasPrecision(10, 2);

            // Document - PatientProfile (Many-to-One)
            modelBuilder.Entity<Document>()
                .HasOne(d => d.PatientProfile)
                .WithMany(p => p.Documents)
                .HasForeignKey(d => d.PatientID);
        }
    }
}
