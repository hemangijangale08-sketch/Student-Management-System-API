using StudentManagementAPI.Models;
using StudentManagementAPI.DTOs;

namespace StudentManagementAPI.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();
        Task<Student> GetById(int id);
        Task Add(StudentDTO dto);
        Task Update(int id, StudentDTO dto);
        Task Delete(int id);
    }
}