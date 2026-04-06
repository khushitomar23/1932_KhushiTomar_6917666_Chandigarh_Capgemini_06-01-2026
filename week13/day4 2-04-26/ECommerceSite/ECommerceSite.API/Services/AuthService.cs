using AutoMapper;
using ECommerceSite.API.Helpers;
using ECommerceSite.API.Repositories.Interfaces;
using ECommerceSite.API.Services.Interfaces;
using ECommerceSite.Models.DTOs;
using ECommerceSite.Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace ECommerceSite.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly JwtHelper _jwtHelper;
        private readonly IMapper _mapper;

        public AuthService(
            IUserRepository userRepository,
            IRefreshTokenRepository refreshTokenRepository,
            JwtHelper jwtHelper,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _jwtHelper = jwtHelper;
            _mapper = mapper;
        }

        public async Task<TokenResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            if (!VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            var accessToken = _jwtHelper.GenerateAccessToken(user.Id, user.Username, user.Role);
            var refreshToken = _jwtHelper.GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = user.Id
            };

            await _refreshTokenRepository.AddAsync(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = DateTime.UtcNow.AddHours(1)
            };
        }

        public async Task<TokenResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(registerDto.Username);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Username already exists");
            }

            var existingEmail = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (existingEmail != null)
            {
                throw new InvalidOperationException("Email already exists");
            }

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                FullName = registerDto.FullName,
                PasswordHash = HashPassword(registerDto.Password),
                Role = "User"
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var accessToken = _jwtHelper.GenerateAccessToken(user.Id, user.Username, user.Role);
            var refreshToken = _jwtHelper.GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = user.Id
            };

            await _refreshTokenRepository.AddAsync(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresIn = DateTime.UtcNow.AddHours(1)
            };
        }

        public async Task<TokenResponseDto> RefreshTokenAsync(string token)
        {
            var refreshTokenEntity = await _refreshTokenRepository.GetValidTokenAsync(token);
            if (refreshTokenEntity == null)
            {
                throw new UnauthorizedAccessException("Invalid or expired refresh token");
            }

            var user = await _userRepository.GetByIdAsync(refreshTokenEntity.UserId);
            var accessToken = _jwtHelper.GenerateAccessToken(user.Id, user.Username, user.Role);
            var newRefreshToken = _jwtHelper.GenerateRefreshToken();

            var newRefreshTokenEntity = new RefreshToken
            {
                Token = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = user.Id
            };

            await _refreshTokenRepository.AddAsync(newRefreshTokenEntity);
            await _refreshTokenRepository.RevokeTokenAsync(token);

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken,
                ExpiresIn = DateTime.UtcNow.AddHours(1)
            };
        }

        public async Task RevokeTokenAsync(string token)
        {
            await _refreshTokenRepository.RevokeTokenAsync(token);
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
            return hashOfInput.Equals(hash);
        }
    }
}
