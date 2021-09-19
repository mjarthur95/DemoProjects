<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSection.aspx.cs" Inherits="TLDR_Capstone.AddSection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="css/main-stylesheet.css"/>
    <title>Add Section</title>
</head>
<body onunload="opener.location.reload();">
    <form id="form1" class="verify-box" runat="server">
        <div style="text-align: center">
        	<asp:Label ID="deptID" runat="server" Text="Dept ID" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="deptIDTB" CssClass="input-field" runat="server" BackColor="#88D4F2">Enter Dept ID</asp:TextBox>
			<br />
			<asp:Label ID="courseNum" runat="server" Text="Course #" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="courseNumTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Course #</asp:TextBox>
			<br />
			<asp:Label ID="courseTitle" runat="server" Text="Course Title" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="courseTitleTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Course Title</asp:TextBox>
        	<br />
        	<asp:Label ID="sectionID" runat="server" Text="Section ID" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="sectionIDTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Section ID</asp:TextBox>
			<br />
			<asp:Label ID="instructor" runat="server" Text="Instructor" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="instructorTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Section Instructor Name</asp:TextBox>
			<br />
			<asp:Label ID="days" runat="server" Text="Course Days" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="daysTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Section Meeting Days</asp:TextBox>
			<br />
			<asp:Label ID="start" runat="server" Text="Start Time" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="startTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Section Start Time</asp:TextBox>
			<br />
			<asp:Label ID="end" runat="server" Text="End Time" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large"></asp:Label>
			<asp:TextBox ID="endTB" CssClass="input-field" runat="server" BackColor="SkyBlue">Enter Section End Time</asp:TextBox>
        </div>
		<div style="text-align:center">
			<asp:Button ID="Save" class="submit-btn" runat="server" Text="Add Section" OnClick="Save_Click"/>
		</div>
	</form>
</body>
</html>
