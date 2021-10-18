<%@ Page Title="Verify Email" Language="C#" AutoEventWireup="true" CodeBehind="Verify.aspx.cs" Inherits="TLDR_Capstone.Contact" %>


<html><head>
<title>Verify Account</title>
	<link rel="stylesheet" href="css/main-stylesheet.css">
</head>
<body>
	<div class="Main">
		<div class="form-box">
			<br><br>
			</div>
		    	<form id="Verify" class="input-group" runat="server">
					<div>Email:  <asp:TextBox runat="server" class="input-field" ID="emailVerTB" Height="20px"></asp:TextBox></div>
					<asp:Button ID="verBtn" class="submit-btn" runat="server" Text="Verify Email" OnClick="verBtn_Click1" /><br>
					<asp:Label ID="debug" runat="server" Text="debug"></asp:Label>
		    	</form>
		</div>
	
</body>
</html>