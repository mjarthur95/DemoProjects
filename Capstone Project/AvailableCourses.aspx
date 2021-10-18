<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AvailableCourses.aspx.cs" Inherits="TLDR_Capstone.AvailableCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Available Courses</title>
    <link rel="stylesheet" href="css/interior-stylesheet.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <h1>Available Courses</h1>
        </div>
        <div style="text-align:center">
			<asp:Label ID="Directions" runat="server" Text="Directions"></asp:Label>
        </div>
        <div style="text-align:center">
			<asp:Label ID="userandlvl" runat="server" Text="User"></asp:Label>
        </div>
        <div>
			<asp:GridView ID="availableCoursesGV" runat="server" AutoGenerateColumns="False">
                <Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkbox" />
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField DataField="Course"/>
                </Columns>
			</asp:GridView>
        </div>
        <div>
			<asp:Button ID="select" class="submit-btn" runat="server" Text="Select" OnClick="select_Click" />
        </div>
        <div>
			<asp:Label ID="selectedcourses" runat="server" Text="Label" Width="200px" Font-Bold="True" Font-Names="Franklin Gothic Demi" Font-Size="Medium"></asp:Label>
        </div>
    </form>
</body>
</html>
