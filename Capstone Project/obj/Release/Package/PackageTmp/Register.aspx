<%@ Page Title="Register User Page" Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TLDR_Capstone.Register" %>
<head>
<link rel="stylesheet" href="css/main-stylesheet.css"></head>
<body>
	<h1>Schedule Planner: Register User</h1>
	<form runat="server">
	<div class="form-box">
			<div style="text-align: center;">Registration Form</div>
		<br />
			<div>Username:  <asp:TextBox runat="server" class="input-field" ID="userTB" Height="20px"></asp:TextBox></div>
			<div>Password:  <asp:TextBox ID="passTB" class="input-field" runat="server" Height="20px" TextMode="Password"></asp:TextBox></div>
			<div>Confirm Password:  <asp:TextBox ID="passConfTB" class="input-field" runat="server" Height="20px" TextMode="Password"></asp:TextBox></div>
			<div>Email:  <asp:TextBox ID="emailTB" class="input-field" runat="server" Height="20px"></asp:TextBox></div>

			<div>Access Level Requested:  </div>
			<div style="height: 30px">
				<asp:DropDownList ID="accessLvlDD" runat="server" Height="20px">
					<asp:ListItem Value="1">Student</asp:ListItem>
					<asp:ListItem Value="2">Admin</asp:ListItem>
					<asp:ListItem Value="3">Root User</asp:ListItem>
				</asp:DropDownList>
			</div>			
			<div style="text-align: center">
		<asp:Button ID="regBtn" class="submit-btn" runat="server" Text="Register" OnClick="regBtn_Click1" /><br />
		<asp:Label ID="debug" runat="server" Text="debug"></asp:Label>
	</div>
	</div>

	</form>
	</body>