<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReservedTimes.aspx.cs" Inherits="TLDR_Capstone.ReservedTimes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reserved Times</title>
</head>
<body>
    <form id="reserveform" runat="server">
		<div style="text-align: center">
			<h2>Reserved Times</h2>
		</div>
		<div>
			<h4>
				<asp:Label ID="userandlvl" runat="server" Text="Label"></asp:Label></h4>
		</div>
		<div style="text-align: center">
			<asp:GridView ID="reservedTimeView" runat="server" AutoGenerateColumns="False" width="100%" DataSourceID="SqlDataSource1">
			<HeaderStyle CssClass="HeaderStyle" />
             <RowStyle CssClass="RowStyle" />
             <AlternatingRowStyle CssClass="AlternatingRowStyle" />
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="reservedDay" SortExpression="reservedDay" />
					<asp:BoundField DataField="reservedStartTime" SortExpression="reservedStartTime" />
					<asp:BoundField DataField="reservedEndTime" SortExpression="reservedEndTime" />
				</Columns>
			</asp:GridView>
		</div>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:capstoneDatabase%>" SelectCommand="SELECT [reservedDay], [reservedStartTime],  [reservedEndTime] FROM [ReservedList]"></asp:SqlDataSource>

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
