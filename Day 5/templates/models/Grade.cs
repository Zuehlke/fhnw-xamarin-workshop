using System;

namespace Mvx.Exercises.Models
{
    public class Grade
    {
        public decimal Achieved { get; set; }

        public DateTime Date { get; set; }

        public Course Course { get; set; }

        public override string ToString()
        {
            return $"{nameof(Achieved)}: {Achieved}, {nameof(Date)}: {Date}, {nameof(Course)}: {Course}";
        }
    }
}