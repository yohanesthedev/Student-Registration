<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Courses</title>
    <%-- Use Bootstrap to style the page --%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    
    <%-- Jquery required by Bootstrap  --%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
    <%-- Bootstrap's Javascript library --%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <h1  style="padding:5px">Algonquin College Course Registration</h1>
        <br />
        <form id="form1" runat="server">
           <div class="row form-group">
                <div class="col-md-2" style="padding-top:5px"> 
                    <asp:Label runat="server" ID="lblName"></asp:Label> Student Name:
                </div>
               <div class="col-md-4">
                    <asp:DropDownList id="studentList"
                        CssClass="form-control"
                        AutoPostBack="True"
                        OnSelectedIndexChanged ="ShowCheckedBoxes"
                        runat="server">
                      <asp:ListItem Selected="True" Value="Select"> Select...</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStudent" runat="server" 
                        ErrorMessage="Must Select one"
                        ForeColor="Red" ControlToValidate="studentList" 
                        InitialValue="Select" Display="Dynamic"></asp:RequiredFieldValidator>
               </div>
                <br /><br />
            </div>
            <asp:Label runat="server" ID="courseLoad" Visible="false"/>
            <asp:Label runat="server" ID="errorCourse" Visible="false"/>
            <div class="row form-group">
                <div class="col-md-6">
                    <asp:Panel runat="server" ID="pnlCourses" Visible="true"> 
                        <p style="font-weight: bold;">The following courses are currently available for registration</p>
                        <br />
                        <asp:CheckBoxList ID="courseList" runat="server" />
                        <br /><br />
                    </asp:Panel>
                </div>
            </div>
            <div class="row form-group">
                    <div class="col-md-2">
                        <asp:Button ID="saveCourse" Text="Save" runat="server" CssClass="form-control btn btn-primary" OnClick="SaveCourse" />
                    </div>
             </div>
            </form>
        <a href ="AddStudent.aspx">Add student</a>
    </div>
</body>
</html>
