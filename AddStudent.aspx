<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Students</title>
    <%-- Use Bootstrap to style the page --%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    
    <%-- Jquery required by Bootstrap  --%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
    <%-- Bootstrap's Javascript library --%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <h1 style="padding:5px">Students</h1>
        <hr />
        <form id="form1" runat="server">
            <div class="row form-group">
                <div class="col-md-2" style="padding-top:5px"> 
                    <asp:Label runat="server" ID="labelName"></asp:Label> Student:
                </div>
                <div class="col-md-4"><asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox></div>
                 <asp:RequiredFieldValidator ID="rqvTxt" runat="server"
                 ForeColor="Red" Display="Dynamic"
                 ControlToValidate="txtName" EnableClientScript="true">Required!</asp:RequiredFieldValidator>
            </div>
            <div class="row form-group">
                <div class="col-md-2" style="padding-top:5px"> 
                    <asp:Label runat="server" ID="labelType"></asp:Label> Student Type:
                </div>
                <div class="col-md-4">
                    <asp:DropDownList id="typeList"
                        CssClass="form-control"
                        AutoPostBack="False"
                        runat="server">
                      <asp:ListItem Selected="True" Value="Select"> Select... </asp:ListItem>
                      <asp:ListItem Value="fullTime"> Full Time </asp:ListItem>
                      <asp:ListItem Value="partTime"> Part Time </asp:ListItem>
                      <asp:ListItem Value="coop"> Co-op </asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvType" runat="server" 
                        ErrorMessage="Must Select one"
                        ForeColor="Red" ControlToValidate="typeList" 
                        InitialValue="Select" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
             <div class="row form-group">
                    <div class="col-md-2">
                        <asp:Button ID="addCourse" Text="Add" runat="server" CssClass="form-control btn btn-primary" OnClick ="AddCourse" />
                    </div>
             </div>
            <asp:Label runat="server" ID="listCount"></asp:Label>
            <asp:Label runat="server" ID="clickCount"></asp:Label>
        </form>
         <asp:Panel runat="server" ID="pnlResult" Visible="true" >
        <asp:Table ID="tblStudent" runat="server" class="table"> 
            <asp:TableHeaderRow>
                <asp:TableHeaderCell style="background-color: #b9c9fe;">ID</asp:TableHeaderCell>
                <asp:TableHeaderCell style="background-color: #b9c9fe;">Name</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell ID="errorCell1" runat="server"></asp:TableCell>
                <asp:TableCell ID="errorCell2" runat="server"> </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <a href ="RegisterCourse.aspx">Register Courses</a>
   </div>  
</body>
</html>
