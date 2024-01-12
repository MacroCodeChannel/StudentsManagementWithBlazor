using StudentsManagement.Client.StudentRepository;
using StudentsManagement.Shared.Models;
using System.Net.Http.Json;

namespace StudentsManagement.Client.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient) 
        { 
            this._httpClient = httpClient;
        }


        public async Task<Student> AddStudentAsync(Student student)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/Student/Add-Student", student);
            var response = await newstudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            var newstudent = await _httpClient.DeleteAsync($"api/Student/DeleteStudent/{id}");
            var response = await newstudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var allstudents = await _httpClient.GetAsync("api/Student/All-Students");
            var response = await allstudents.Content.ReadFromJsonAsync<List<Student>>();
            return response;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var singlestudents = await _httpClient.GetAsync($"api/Student/Single-Student/{studentId}");
            var response = await singlestudents.Content.ReadFromJsonAsync<Student>();
            return response;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var newstudent = await _httpClient.PostAsJsonAsync("api/Student/Update-Student", student);
            var response = await newstudent.Content.ReadFromJsonAsync<Student>();
            return response;
        }
    }
}
