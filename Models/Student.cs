using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }

        public List<Course> RegisteredCourses { get; }
        public Student(string name)
        {
            Name = name;
            Random rand = new Random();
            Id = rand.Next(100000, 999999);
            RegisteredCourses = new List<Course>(); 
        }

        //removes all elements in registeredCourses and replaces it with selected courses
        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();

            foreach(Course course in selectedCourses)
            {
                RegisteredCourses.Add(course);
            }

        }

        public int TotalWeeklyHours()
        {
            int totalWeeklyHours = 0;
            foreach(Course course in RegisteredCourses)
            {
                totalWeeklyHours += course.WeeklyHours;
            }
            return totalWeeklyHours;
        }

    }

   
}