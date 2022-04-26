using Lab8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        List<Student> students = new List<Student>();
        protected void Page_Load(object sender, EventArgs e)
        {
   
            if (Session["students"] == null)
            {
                errorCell1.ColumnSpan = 2;
                errorCell1.Text = "No students yet";
                errorCell1.Style.Add("color", "red");
                errorCell1.Style.Add("text-align", "center");
                errorCell1.Visible = true;
            }
            else
            {
                errorCell1.Visible = false;
                errorCell2.Visible = false;
                students = Session["students"] as List<Student>;
            }
        }

        protected void AddCourse(object sender, EventArgs e)
        {
            //check if dropdown list is selected 
            if (typeList.SelectedValue != "Select" && txtName.Text != "")
            {
                if (typeList.SelectedValue == "fullTime")
                {
                    Student s = new FulltimeStudent(txtName.Text);
                    students.Add(s);
                }
                if (typeList.SelectedValue == "partTime")
                {
                    Student s = new ParttimeStudent(txtName.Text);
                    students.Add(s);
                }
                if (typeList.SelectedValue == "coop")
                {
                    Student s = new CoopStudent(txtName.Text);
                    students.Add(s);
                }
                typeList.SelectedValue = "Select";
                txtName.Text = "";
                Session["students"] = students;
            }


            //populate table with list of students 
            if (students.Count != 0)
            {
                errorCell1.Visible = false;
                errorCell2.Visible = false;
                students = Session["students"] as List<Student>;
                foreach (Student s in students)
                {
                    TableRow rowNew = new TableRow();
                    tblStudent.Rows.Add(rowNew);

                    TableCell cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = s.Id.ToString();

                    cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = s.Name;
                    
                }

            }
      
        }
    }
}