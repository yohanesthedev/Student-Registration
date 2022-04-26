using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Student> students = new List<Student>();
        protected void Page_Load(object sender, EventArgs e)
        {
            students = Session["students"] as List<Student>;

            //display registered students in drop down select
            if (students.Count != 0)
            {   
                if (!IsPostBack)
                {
                    foreach (Student s in students)
                    {
                        studentList.Items.Add(new ListItem(s.ToString()));
                    }
                }

                 
            }

            //display available courses for selection
            if (!IsPostBack)
            {
                foreach (Course x in Helper.GetAvailableCourses())
                {
                    courseList.Items.Add(new ListItem(x.Title + " - " + x.WeeklyHours + " hours/week", x.Code));
                }
            }

            //dipslay lable showing summary of courses and hours
            foreach(Student s in students)
            {
                int idxStudent;
                idxStudent = studentList.SelectedIndex - 1;
                if (students.Count != 0)
                {
                    if(idxStudent == students.IndexOf(s))
                    {
                        courseLoad.Text = $"Selected student has registered {s.RegisteredCourses.Count} course(s), {s.TotalWeeklyHours()} hours weekly";
                        courseLoad.Style.Add("color", "blue");
                        courseLoad.Visible = true;
                        errorCourse.Visible = false;
                    } 

                    else if (studentList.SelectedIndex == 0)
                    {
                        courseLoad.Visible=false;
                    }

                }
            }
        }

        protected void SaveCourse(object sender, EventArgs e)
        {
            //add selected courses from checkbox to list of selected courses using register course method
            List <Course> coursesList = Helper.GetAvailableCourses();
            List<Course> selectedCourses = new List<Course>();
            students = Session["students"] as List<Student>;

            int idxCourse = 0;
            foreach (ListItem lstItem in courseList.Items)

            {
                if (lstItem.Selected == true)
                {
                    selectedCourses.Add(coursesList[idxCourse]);
                    
                }
                idxCourse++;
            }

            if (students.Count != 0)
            {   
                try
                {
                    int idxStudent;
                    idxStudent = studentList.SelectedIndex - 1;
                    students[idxStudent].RegisterCourses(selectedCourses);
                    courseLoad.Text = $"Selected student has registered {selectedCourses.Count} course(s), {students[idxStudent].TotalWeeklyHours()} hours weekly";
                    courseLoad.Style.Add("color", "blue");
                    courseLoad.Visible = true;
                    errorCourse.Visible = false;
                    Session["students"] = students;
                }

                catch (Exception ex)
                {
                    courseLoad.Visible = false;
                    errorCourse.Visible = true;
                    errorCourse.Style.Add("color", "red");
                    errorCourse.Text = ex.Message;  
                }
                
            }

        }

        protected void ShowCheckedBoxes(object sender, EventArgs e)
        {   

            //select checkbox list for courses student is already registered
            courseList.ClearSelection();
            List<Course> coursesList = Helper.GetAvailableCourses();
            students = Session["students"] as List<Student>;
            foreach (ListItem student in studentList.Items)
            {
                if ((student.Selected == true) && (studentList.SelectedValue != "Select"))
                {
                    int idxStudent;
                    idxStudent = studentList.SelectedIndex - 1;
                    if (students[idxStudent].RegisteredCourses.Count != 0)
                    { 
                        for (int i = 0; i < students[idxStudent].RegisteredCourses.Count; i++)
                        {   
                            for(int j = 0; j < courseList.Items.Count; j++)

                            {
             
                                if (students[idxStudent].RegisteredCourses[i].Code == coursesList[j].Code)
                                {
                                    courseList.Items[j].Selected = true;
                                }
                            }
                               
                        }
                            
                    }
                 
                }
            }
        }
    }

}