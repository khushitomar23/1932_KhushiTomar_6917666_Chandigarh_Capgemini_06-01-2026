using HealthcareShared.DTOs;
using HealthcareShared.Models;

namespace HealthcareAPI.Services
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<(bool success, string message, UserDto user)> LoginAsync(LoginDto loginDto);
    }

    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<IEnumerable<DoctorDto>> GetDoctorsByDepartmentAsync(int departmentId);
        Task<DoctorDto> GetDoctorByIdAsync(int doctorId);
        Task<DoctorDto> GetDoctorByUserIdAsync(int userId);
        Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto dto);
        Task<DoctorDto> UpdateDoctorAsync(int doctorId, UpdateDoctorDto dto);
        Task DeleteDoctorAsync(int doctorId);
    }

    public interface IAppointmentService
    {
        Task<AppointmentDto> BookAppointmentAsync(int patientId, CreateAppointmentDto dto);
        Task<IEnumerable<AppointmentDto>> GetPatientAppointmentsAsync(int patientId);
        Task<IEnumerable<AppointmentDto>> GetDoctorAppointmentsAsync(int doctorId);
        Task<AppointmentDto> CancelAppointmentAsync(int appointmentId);
    }

    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllPatientsAsync();
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<UserDto> UpdatePatientAsync(int userId, UpdatePatientDto dto);
        Task DeletePatientAsync(int userId);
    }
}
