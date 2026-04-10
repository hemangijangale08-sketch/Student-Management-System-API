using StudentManagementAPI.Models;
using StudentManagementAPI.DTOs;
using StudentManagementAPI.Repositories;
using Microsoft.Extensions.Logging;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repo, ILogger<StudentService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // ✅ GET ALL STUDENTS
        public async Task<List<Student>> GetAll()
        {
            _logger.LogInformation("Fetching all students");

            var students = await _repo.GetAll();

            if (students == null || students.Count == 0)
            {
                _logger.LogWarning("No students found");
            }

            return students ?? new List<Student>(); // safe return
        }

        // ✅ GET BY ID
        public async Task<Student> GetById(int id)
        {
            _logger.LogInformation($"Fetching student with ID: {id}");

            var student = await _repo.GetById(id);

            if (student == null)
            {
                _logger.LogWarning($"Student not found with ID: {id}");
                throw new Exception("Student not found");
            }

            return student;
        }

        // ✅ ADD STUDENT
        public async Task Add(StudentDTO dto)
        {
            _logger.LogInformation("Adding new student");

            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.Now   // ✅ FIXED (no ;)
            };

            await _repo.Add(student);

            _logger.LogInformation("Student added successfully");
        }

        // ✅ UPDATE STUDENT
        public async Task Update(int id, StudentDTO dto)
        {
            _logger.LogInformation($"Updating student with ID: {id}");

            var student = await _repo.GetById(id);

            if (student == null)
            {
                _logger.LogWarning($"Student not found with ID: {id}");
                throw new Exception("Student not found");
            }

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Course = dto.Course;

            await _repo.Update(student);

            _logger.LogInformation("Student updated successfully");
        }

        // ✅ DELETE STUDENT
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Deleting student with ID: {id}");

            var student = await _repo.GetById(id);

            if (student == null)
            {
                _logger.LogWarning($"Student not found with ID: {id}");
                throw new Exception("Student not found");
            }

            await _repo.Delete(id);

            _logger.LogInformation("Student deleted successfully");
        }
    }
}