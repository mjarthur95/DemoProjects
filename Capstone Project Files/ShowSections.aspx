<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowSections.aspx.cs" Inherits="TLDR_Capstone.ShowSections" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<link rel="stylesheet" href="css/interior-stylesheet.css">
	<title>Catalog</title>
	<script type="text/javascript">
		function popAddWindow()
		{
			window.open("AddSection.aspx", "_blank", "width=400px, height=400px, alignment=center, left=400px, top=200px");
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div style="text-align: center">
			<h1>All Available Sections</h1>
		</div>
		<div style="text-align:center">
			<asp:Label ID="AdminDirections" runat="server" Text=""></asp:Label>
		</div>
		<div>
			<asp:Button ID="AddSection" CssClass="admin-btn" runat="server" Text="Add Section" OnClientClick="return popAddWindow();" />
			<asp:Button ID="deleteBtn" CssClass="admin-btn" runat="server" OnClick="deleteBtn_Click" Text="Delete" />
			<asp:Button ID="refresh" CssClass="admin-btn" runat="server" OnClick="refresh_Click" Text="Refresh" />
		</div>
				<div style="text-align:center">
			<asp:Label ID="Directions" runat="server" Text="To select courses to add to your schedule, please use the Course Catalog Page"></asp:Label>
		</div>
		<div style="text-align: center">
			<asp:GridView ID="scheduleGridview" runat="server" AutoGenerateColumns="False" width="100%" DataSourceID="SqlDataSource1">
			<HeaderStyle CssClass="HeaderStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="deptID" HeaderText="Dept. ID" SortExpression="deptID" />
					<asp:BoundField DataField="courseNumber" HeaderText="Course Number" SortExpression="courseNumber" />
					<asp:BoundField DataField="courseTitle" HeaderText="Course Title" SortExpression="courseTitle" />
					<asp:BoundField DataField="sectionID" HeaderText="Section ID" SortExpression="sectionID" />
					<asp:BoundField DataField="instructor" HeaderText="Instructor" SortExpression="instructor" />
					<asp:BoundField DataField="days" HeaderText="Meeting Days" SortExpression="days" />
					<asp:BoundField DataField="startTime" HeaderText="Start Time" SortExpression="startTime" />
					<asp:BoundField DataField="endTime" HeaderText="End Time" SortExpression="endTime" />
				</Columns>
			</asp:GridView>
		</div>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:capstoneDatabaseConnectionString %>" SelectCommand="SELECT [deptID], [courseNumber], [courseTitle], [sectionID], [instructor], [days], [startTime], [endTime] FROM [Schedule] ORDER BY [deptID], [courseNumber]"></asp:SqlDataSource>
	</form>
</body>
</html>
