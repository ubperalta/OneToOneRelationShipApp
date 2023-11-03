using OneOne.Shared.Entities;
using OneOne.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace OneOne.Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _factory;
        private readonly JsonSerializerOptions _options;
        public StudentService(HttpClient factory)
        {
            _factory = factory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            var response = await _factory.PostAsJsonAsync("api/students", student);
            var results = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Student>(results, _options);
        }

        public async Task<StudentModel> GetStudentByIdAsync(int id)
        {
            return await _factory.GetFromJsonAsync<StudentModel>($"api/students/{id}");
        }

        public async Task<IEnumerable<StudentModel>> GetStudentsAsync()
        {
            return await _factory.GetFromJsonAsync<IEnumerable<StudentModel>>("api/students");
        }
    }
}
