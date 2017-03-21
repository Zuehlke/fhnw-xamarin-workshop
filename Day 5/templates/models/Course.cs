using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvx.Exercises.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Teacher { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Teacher)}: {Teacher}";
        }
    }
}
