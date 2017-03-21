using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvx.Exercises.Models;

namespace Mvx.Exercises.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentById(int id);

        Task AddGrade(int studentId, Grade achieved);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>
        {
            new Student
            {
                Id = 2,
                Name = "Hausi Hinterseeher",
                Courses = new List<Course>
                {
                    new Course
                    {
                        Id = 1,
                        Name = "Emoba",
                        Teacher = "someone"
                    },
                    new Course
                    {
                        Id = 2,
                        Name = "Other Course",
                        Teacher = "someone else"
                    }
                },
                Grades = new List<Grade>()
            }
        };

        public Task<Student> GetStudentById(int id)
        {
            return Task.FromResult(_students.FirstOrDefault(_ => _.Id.Equals(id)));
        }

        public async Task AddGrade(int studentId, Grade achieved)
        {
            var student = await GetStudentById(studentId);
            student.Grades.Add(achieved);
        }
    }
}