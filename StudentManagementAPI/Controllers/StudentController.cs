using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Services;
using StudentManagementAPI.DTOs;
using Microsoft.Extensions.Logging;
using System;

namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    [Authorize] // 🔐 JWT protection
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService service, ILogger<StudentController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // ✅ GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("GET all students called");

            var students = await _service.GetAll();

            return Ok(students);
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"GET student by ID: {id}");

            var student = await _service.GetById(id);

            return Ok(student);
        }

        // ✅ ADD STUDENT
        [HttpPost]
        public async Task<IActionResult> Add(StudentDTO dto)
        {
            _logger.LogInformation("Adding student");

            await _service.Add(dto);

            return Ok(new { message = "Student added successfully" });
        }

        // ✅ UPDATE STUDENT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDTO dto)
        {
            _logger.LogInformation($"Updating student ID: {id}");

            await _service.Update(id, dto);

            return Ok(new { message = "Student updated successfully" });
        }

        // ✅ DELETE STUDENT
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Deleting student ID: {id}");

            await _service.Delete(id);

            return Ok(new { message = "Student deleted successfully" });
        }

        // ✅ TEST EXCEPTION (Middleware check)
        [AllowAnonymous]
        [HttpGet("test-error")]
        public IActionResult TestError()
        {    
            return StatusCode(500,new { message= "Test error" });
            throw new Exception();
        }
    }
}