<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="TLDR_Capstone.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="css/main-stylesheet.css"/>
    <title>Add Courses</title>>
</head>
<body>
    <form id="form1" class="verify-box" runat="server">
        <div style="text-align: center">
        	<asp:Label ID="deptID" runat="server" Text="Dept ID" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="deptIDTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Dept ID</asp:TextBox>
			<br />
			<asp:Label ID="courseNum" runat="server" Text="Course #" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="courseNumTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Course #</asp:TextBox>
			<br />
			<asp:Label ID="courseTitle" runat="server" Text="Course Title" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="courseTitleTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Course Title</asp:TextBox
>
        </div>
		<div style="text-align:center">
			<asp:Button ID="Save" CssClass="submit-btn" runat="server" Text="Add Course" OnClick="Save_Click"/>
		</div>
	</form>
</body>
</html>
