<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationQueue.aspx.cs" Inherits="TLDR_Capstone.RegistrationQueue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" href="css/interior-stylesheet.css"/>
    <title>Registration Queue</title>
</head>
<body>
    <form id="registrationQueueForm" runat="server">
		<div style="text-align: center">
			<h1>Registration Queue</h1>
		</div>
		<div>
			<h4>
				<asp:Label ID="userandlvl" runat="server" Text="Label"></asp:Label></h4>
		</div>
		<div style="text-align: center">
			<asp:GridView ID="registrationGridView" runat="server" AutoGenerateColumns="False" width="100%" DataSourceID="SqlDataSource2">
			<HeaderStyle CssClass="HeaderStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="username" SortExpression="username" />
					<asp:BoundField DataField="email" SortExpression="email" />
					<asp:BoundField DataField="authlevel" SortExpression="authlevel" />
				</Columns>
			</asp:GridView>
		</div>
		<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:capstoneDatabase%>" SelectCommand="SELECT [username], [email], [authlevel] FROM [Users] WHERE ([authorized] = 0) AND NOT ([authlevel] = 0)">
		</asp:SqlDataSource>

		<div>
			<asp:Button class="submit-btn" ID="regisQueueBtn" runat="server" Font-Size="Medium" Font-Names="Franklin Gothic Demi" Text="Confirm Registration" OnClick="regisQueueBtn_Click" /><br />
		</div>
		<div>
			<h4>
				<asp:Label ID="selected" runat="server" Text="Verified Users: "></asp:Label></h4><br />
		</div>
	</form>
</body>
</html>
