using LearningPlatform.API.Data;
using LearningPlatform.API.DTOs;
using LearningPlatform.API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LearningPlatform.API.Services
{
    public class CourseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "all_courses";

        public CourseService(AppDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(CacheKey, out List<CourseDto>? cached))
                return cached!;

            var courses = await _context.Courses
                .Include(c => c.Instructor)
                .ToListAsync();

            var result = _mapper.Map<List<CourseDto>>(courses);
            _cache.Set(CacheKey, result, TimeSpan.FromMinutes(5));
            return result;
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Instructor)
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == id);

            return course == null ? null : _mapper.Map<CourseDto>(course);
        }

        public async Task<List<CourseDto>> GetByCategoryAsync(string category)
        {
            var courses = await _context.Courses
                .Include(c => c.Instructor)
                .Where(c => c.Category.ToLower() == category.ToLower())
                .ToListAsync();

            return _mapper.Map<List<CourseDto>>(courses);
        }

        public async Task<CourseDto> CreateAsync(CreateCourseDto dto)
        {
            var course = _mapper.Map<Course>(dto);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            _cache.Remove(CacheKey);

            var created = await _context.Courses
                .Include(c => c.Instructor)
                .FirstAsync(c => c.Id == course.Id);

            return _mapper.Map<CourseDto>(created);
        }

        public async Task<LessonDto?> AddLessonAsync(int courseId, CreateLessonDto dto)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null) return null;

            var lesson = _mapper.Map<Lesson>(dto);
            lesson.CourseId = courseId;
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            return _mapper.Map<LessonDto>(lesson);
        }

        public async Task<bool> EnrollAsync(EnrollmentDto dto)
        {
            var exists = await _context.Enrollments
                .AnyAsync(e => e.UserId == dto.UserId && e.CourseId == dto.CourseId);
            if (exists) return false;

            _context.Enrollments.Add(new Enrollment
            {
                UserId = dto.UserId,
                CourseId = dto.CourseId
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnenrollAsync(EnrollmentDto dto)
        {
            var enrollment = await _context.Enrollments
                .FirstOrDefaultAsync(e => e.UserId == dto.UserId && e.CourseId == dto.CourseId);

            if (enrollment == null) return false;

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CourseDto>> GetEnrollmentsByUserAsync(int userId)
        {
            var enrollments = await _context.Enrollments
                .Where(e => e.UserId == userId)
                .Include(e => e.Course)
                    .ThenInclude(c => c.Instructor)
                .ToListAsync();

            return _mapper.Map<List<CourseDto>>(enrollments.Select(e => e.Course).ToList());
        }
    }
}