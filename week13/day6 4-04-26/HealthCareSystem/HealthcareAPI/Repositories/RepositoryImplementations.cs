using HealthcareShared.Data;
using HealthcareShared.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAPI.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HealthcareDbContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }

    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthcareDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _dbSet
                .Include(d => d.User)
                .Include(d => d.Department)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByDepartmentAsync(int departmentId)
        {
            return await _dbSet
                .Where(d => d.DepartmentId == departmentId)
                .Include(d => d.User)
                .Include(d => d.Department)
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorWithUserAsync(int doctorId)
        {
            return await _dbSet
                .Include(d => d.User)
                .Include(d => d.Department)
                .FirstOrDefaultAsync(d => d.DoctorId == doctorId);
        }
    }

    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HealthcareDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetPatientAppointmentsAsync(int patientId)
        {
            return await _dbSet
                .Where(a => a.PatientId == patientId)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(int doctorId)
        {
            return await _dbSet
                .Where(a => a.DoctorId == doctorId)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
        }

        public async Task<bool> HasConflictingAppointmentAsync(int patientId, int doctorId, DateTime appointmentDate)
        {
            return await _dbSet.AnyAsync(a =>
                a.PatientId == patientId &&
                a.DoctorId == doctorId &&
                a.Status != "Cancelled" &&
                a.AppointmentDate.Date == appointmentDate.Date);
        }
    }
}
