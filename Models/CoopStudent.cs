using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name)
            : base(name)
        {

        }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int hours = 0;
            foreach (Course c in selectedCourses) { hours += c.WeeklyHours; }

            if (hours > MaxWeeklyHours)
            {
                throw new Exception($"Cannot exceed {CoopStudent.MaxWeeklyHours} hours");
            }
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception($"Cannot exceed {CoopStudent.MaxNumOfCourses} courses");
            }
           
            base.RegisterCourses(selectedCourses);
            
        }

        public override string ToString()
        {
            return $"{Id} {Name} (Coop)";
        }
    }
}