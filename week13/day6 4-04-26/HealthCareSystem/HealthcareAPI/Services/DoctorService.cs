using HealthcareShared.DTOs;
using HealthcareAPI.Repositories;
using HealthcareShared.Models;

namespace HealthcareAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;

        public DoctorService(IDoctorRepository doctorRepository, IUserRepository userRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return doctors.Select(d => MapToDoctorDto(d)).ToList();
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsByDepartmentAsync(int departmentId)
        {
            var doctors = await _doctorRepository.GetDoctorsByDepartmentAsync(departmentId);
            return doctors.Select(d => MapToDoctorDto(d)).ToList();
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(int doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorWithUserAsync(doctorId);
            return doctor != null ? MapToDoctorDto(doctor) : null;
        }

        public async Task<DoctorDto> GetDoctorByUserIdAsync(int userId)
        {
            var allDoctors = await _doctorRepository.GetAllAsync();
            var doctor = allDoctors.FirstOrDefault(d => d.UserId == userId);
            
            if (doctor == null)
                return null;
            
            // Load the full doctor details with user information
            var fullDoctor = await _doctorRepository.GetDoctorWithUserAsync(doctor.DoctorId);
            return fullDoctor != null ? MapToDoctorDto(fullDoctor) : null;
        }

        public async Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto dto)
        {
            // Check if email already exists
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new InvalidOperationException("Email already exists");

            // Create user record
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = dto.Password, // In production, this should be hashed
                Role = "Doctor"
            };
            var createdUser = await _userRepository.AddAsync(user);

            // Create doctor record
            var doctor = new Doctor
            {
                UserId = createdUser.UserId,
                DepartmentId = dto.DepartmentId,
                Specialization = dto.Specialization,
                ExperienceYears = dto.ExperienceYears,
                Availability = dto.Availability
            };
            var createdDoctor = await _doctorRepository.AddAsync(doctor);

            // Reload with includes
            var doctorWithDetails = await _doctorRepository.GetDoctorWithUserAsync(createdDoctor.DoctorId);
            return MapToDoctorDto(doctorWithDetails);
        }

        public async Task<DoctorDto> UpdateDoctorAsync(int doctorId, UpdateDoctorDto dto)
        {
            var doctor = await _doctorRepository.GetDoctorWithUserAsync(doctorId);
            if (doctor == null)
                throw new InvalidOperationException("Doctor not found");

            // Update user details
            doctor.User.FullName = dto.FullName;
            doctor.User.Email = dto.Email;
            await _userRepository.UpdateAsync(doctor.User);

            // Update doctor details
            doctor.DepartmentId = dto.DepartmentId;
            doctor.Specialization = dto.Specialization;
            doctor.ExperienceYears = dto.ExperienceYears;
            doctor.Availability = dto.Availability;
            await _doctorRepository.UpdateAsync(doctor);

            // Reload with includes
            var updatedDoctor = await _doctorRepository.GetDoctorWithUserAsync(doctorId);
            return MapToDoctorDto(updatedDoctor);
        }

        public async Task DeleteDoctorAsync(int doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorWithUserAsync(doctorId);
            if (doctor == null)
                throw new InvalidOperationException("Doctor not found");

            // Delete doctor record
            await _doctorRepository.DeleteAsync(doctorId);

            // Delete user record
            await _userRepository.DeleteAsync(doctor.UserId);
        }

        private DoctorDto MapToDoctorDto(dynamic doctor)
        {
            return new DoctorDto
            {
                DoctorId = doctor.DoctorId,
                FullName = doctor.User?.FullName,
                Email = doctor.User?.Email,
                DepartmentId = doctor.DepartmentId,
                DepartmentName = doctor.Department?.DepartmentName,
                Specialization = doctor.Specialization,
                ExperienceYears = doctor.ExperienceYears,
                Availability = doctor.Availability
            };
        }
    }
}
