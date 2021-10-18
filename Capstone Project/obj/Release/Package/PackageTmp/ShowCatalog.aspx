<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCatalog.aspx.cs" Inherits="TLDR_Capstone.ShowCatalog" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<link rel="stylesheet" href="css/interior-stylesheet.css">
	<title>Catalog</title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="text-align: center">
			<h2>Course Catalog</h2>
		</div>
		<div>
			<h4>
				<asp:Label ID="userandlvl" runat="server" Text="Label"></asp:Label></h4>
		</div>
		<div style="text-align: center">
			<asp:GridView ID="catalogGridview" runat="server" AutoGenerateColumns="False" width="100%" DataSourceID="SqlDataSource1">
			<HeaderStyle CssClass="HeaderStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="deptID" SortExpression="deptID" />
					<asp:BoundField DataField="courseNumber" SortExpression="courseNumber" />
					<asp:BoundField DataField="courseTitle" SortExpression="courseTitle" />
				</Columns>
			</asp:GridView>
		</div>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:capstoneDatabase%>" SelectCommand="SELECT DISTINCT [deptID], [courseNumber], [courseTitle] FROM [Schedule]"></asp:SqlDataSource>

		<div>
			<asp:Button class="submit-btn" ID="selectBtn" runat="server" Text="Select" OnClick="selectBtn_Click" /><br />
		</div>
		<div>
			<h4>
				<asp:Label ID="selected" runat="server" Text="Selected Courses"></asp:Label></h4><br />
		</div>
	</form>
</body>
</html>
