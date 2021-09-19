<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TLDR_Capstone._Default" %>

<head>
	<title>Login form</title>
	<link rel="stylesheet" href="css/main-stylesheet.css">
</head>
<body>
    <h1>Student Schedule Planner: Ultimate Edition</h1>

	<form class="form-box" runat="server">
        		<div style="text-align: center; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; font-size:large";>Login Form

			</div><br />
		<div style="text-align: left;">

			<div>
				<asp:Login ID="Login" runat="server" OnAuthenticate="Login_Authenticate" Width="250px">
                    <LayoutTemplate>
                        <table style="border-collapse:collapse;">
                        <tr><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large">Username</asp:Label>
                        </tr>
                        <tr><asp:TextBox ID="UserName" runat="server" class="input-field" placeholder="********"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="Username is required." ValidationGroup="Login">*</asp:RequiredFieldValidator>
                        </tr>
                        <tr><asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Large">Password</asp:Label>
                        </tr>
                        <tr><asp:TextBox ID="Password" runat="server" class="input-field" placeholder="********" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login">*</asp:RequiredFieldValidator>
                        </tr>
                        <tr><asp:CheckBox ID="RememberMe" runat="server" class="check-box" Text="Remember me" />
                        </tr>
                        <tr><td style="color:Red; text-align:center;">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        </td></tr>
                        <tr><td><asp:Button ID="LoginButton" runat="server" class="submit-btn" CommandName="Login" Text="Log In" ValidationGroup="Login" />
                                              <asp:Button ID="Button" runat="server" class="submit-btn" OnClick="gotoRegBtn_Click" Text="Register" />
                        </td></tr>
                        </div>
                        </table>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
			</div>

		</div>
	</form>
    </body>