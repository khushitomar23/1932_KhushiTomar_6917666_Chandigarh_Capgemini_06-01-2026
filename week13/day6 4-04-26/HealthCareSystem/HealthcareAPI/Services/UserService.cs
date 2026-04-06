using HealthcareShared.DTOs;
using HealthcareAPI.Repositories;
using HealthcareShared.Models;

namespace HealthcareAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllPatientsAsync()
        {
            var patients = await _userRepository.GetAllAsync();
            var patientList = patients.Where(u => u.Role == "Patient").ToList();
            return patientList.Select(u => MapToUserDto(u)).ToList();
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user != null ? MapToUserDto(user) : null;
        }

        public async Task<UserDto> UpdatePatientAsync(int userId, UpdatePatientDto dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new InvalidOperationException("Patient not found");

            if (user.Role != "Patient")
                throw new InvalidOperationException("User is not a patient");

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            await _userRepository.UpdateAsync(user);

            return MapToUserDto(user);
        }

        public async Task DeletePatientAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new InvalidOperationException("Patient not found");

            if (user.Role != "Patient")
                throw new InvalidOperationException("User is not a patient");

            await _userRepository.DeleteAsync(userId);
        }

        private UserDto MapToUserDto(dynamic user)
        {
            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
