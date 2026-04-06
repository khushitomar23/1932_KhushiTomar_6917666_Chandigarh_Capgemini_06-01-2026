using LearningPlatform.API.DTOs;
using LearningPlatform.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers
{
    [ApiController]
    [Route("api/v1/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CoursesController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
                return NotFound(new { error = "Course not found" });
            return Ok(course);
        }

        [HttpGet("category/{name}")]
        public async Task<IActionResult> GetByCategory(string name)
        {
            var courses = await _courseService.GetByCategoryAsync(name);
            return Ok(courses);
        }

        [HttpPost]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = await _courseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPost("{id}/lessons")]
        [Authorize(Roles = "Instructor,Admin")]
        public async Task<IActionResult> AddLesson(int id, CreateLessonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var lesson = await _courseService.AddLessonAsync(id, dto);
            if (lesson == null)
                return NotFound(new { error = "Course not found" });

            return Ok(lesson);
        }

        [HttpGet("/api/v1/enrollments/{userId}")]
        [Authorize]
        public async Task<IActionResult> GetEnrollments(int userId)
        {
            var enrollments = await _courseService.GetEnrollmentsByUserAsync(userId);
            return Ok(enrollments);
        }
    }

    [ApiController]
    [Route("api/v1/enroll")]
    public class EnrollmentController : ControllerBase
    {
        private readonly CourseService _courseService;

        public EnrollmentController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [Authorize(Roles = "Student,Admin")]
        public async Task<IActionResult> Enroll(EnrollmentDto dto)
        {
            var success = await _courseService.EnrollAsync(dto);
            if (!success)
                return BadRequest(new { error = "Already enrolled or invalid data" });

            return Ok(new { message = "Enrolled successfully" });
        }

        [HttpDelete]
        [Authorize(Roles = "Student,Admin")]
        public async Task<IActionResult> Unenroll([FromBody] EnrollmentDto dto)
        {
            var success = await _courseService.UnenrollAsync(dto);
            if (!success)
                return BadRequest(new { error = "Enrollment not found" });

            return Ok(new { message = "Unenrolled successfully" });
        }
    }
}