using HealthcareShared.Models;

namespace HealthcareAPI.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }

    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsByDepartmentAsync(int departmentId);
        Task<Doctor> GetDoctorWithUserAsync(int doctorId);
    }

    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetPatientAppointmentsAsync(int patientId);
        Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(int doctorId);
        Task<bool> HasConflictingAppointmentAsync(int patientId, int doctorId, DateTime appointmentDate);
    }
}
