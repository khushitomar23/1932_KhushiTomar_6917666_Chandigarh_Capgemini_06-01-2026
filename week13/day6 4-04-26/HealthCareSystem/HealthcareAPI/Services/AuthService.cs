using HealthcareShared.DTOs;
using HealthcareShared.Models;
using HealthcareAPI.Repositories;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HealthcareAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            // Validate input
            ValidateRegisterDto(registerDto);

            // Check if email already exists
            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
                throw new InvalidOperationException("Email already exists in the system");

            // Validate email format
            if (!IsValidEmail(registerDto.Email))
                throw new InvalidOperationException("Invalid email format");

            // Validate password strength
            ValidatePasswordStrength(registerDto.Password);

            var user = new User
            {
                FullName = registerDto.FullName.Trim(),
                Email = registerDto.Email.Trim().ToLower(),
                PasswordHash = HashPassword(registerDto.Password),
                Role = (registerDto.Role ?? "Patient").Trim(),
                CreatedAt = DateTime.Now
            };

            var createdUser = await _userRepository.AddAsync(user);
            return MapToUserDto(createdUser);
        }

        public async Task<(bool success, string message, UserDto user)> LoginAsync(LoginDto loginDto)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
                return (false, "Email and password are required", null);

            var user = await _userRepository.GetByEmailAsync(loginDto.Email.Trim().ToLower());
            if (user == null)
                return (false, "Invalid email or password", null);

            if (!VerifyPassword(loginDto.Password, user.PasswordHash))
                return (false, "Invalid email or password", null);

            return (true, "Login successful", MapToUserDto(user));
        }

        private void ValidateRegisterDto(RegisterDto registerDto)
        {
            if (registerDto == null)
                throw new ArgumentNullException(nameof(registerDto));

            if (string.IsNullOrWhiteSpace(registerDto.FullName))
                throw new InvalidOperationException("Full name is required");

            if (registerDto.FullName.Length < 2 || registerDto.FullName.Length > 100)
                throw new InvalidOperationException("Full name must be between 2 and 100 characters");

            if (string.IsNullOrWhiteSpace(registerDto.Email))
                throw new InvalidOperationException("Email is required");

            if (string.IsNullOrWhiteSpace(registerDto.Password))
                throw new InvalidOperationException("Password is required");
        }

        private void ValidatePasswordStrength(string password)
        {
            if (password.Length < 6)
                throw new InvalidOperationException("Password must be at least 6 characters");

            if (!Regex.IsMatch(password, @"[a-z]"))
                throw new InvalidOperationException("Password must contain at least one lowercase letter");

            if (!Regex.IsMatch(password, @"[A-Z]"))
                throw new InvalidOperationException("Password must contain at least one uppercase letter");

            if (!Regex.IsMatch(password, @"\d"))
                throw new InvalidOperationException("Password must contain at least one digit");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hash;
        }

        private UserDto MapToUserDto(User user)
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
