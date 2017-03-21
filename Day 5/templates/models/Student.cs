using System.Collections.Generic;

namespace Mvx.Exercises.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Grade> Grades { get; set; }

        public IList<Course> Courses { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }
}