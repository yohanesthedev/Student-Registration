using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name)
            : base(name)
        {

        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int hours = 0;
            foreach(Course c in selectedCourses) { hours += c.WeeklyHours; }
            if (hours > MaxWeeklyHours)
            {
                throw new Exception($"cannot exceed {FulltimeStudent.MaxWeeklyHours} total weekly hours");
            }
           
            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{Id} {Name} (Full time)";
        }
    }
}