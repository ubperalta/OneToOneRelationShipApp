using OneOne.Shared.Entities;
using OneOne.Shared.Models;

namespace OneOne.Web.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentModel>> GetStudentsAsync();
        Task<StudentModel> GetStudentByIdAsync(int id);
        Task<Student> AddStudentAsync(Student student);
    }
}
