<%@ Page Title="Dashboard" Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TLDR_Capstone.About" %>

<html>
<head>
    <title>Student Dashboard</title>
    <link rel="stylesheet" href="css/main-stylesheet.css">
</head>
<body>
    <div class="header">
        <h1>Student Schedule Planner: Ultimate Edition</h1>
        </div>
    <div class="button-box">
	<ul>
		<li><button class="menu-btn"><a href ="ShowCatalog.aspx" target="window">Course Catalog</button></a></li>
		<li><button class="menu-btn"><a href ="AvailableCourses.aspx" target="window">Available Courses</button></a></li>
		<li><button class="menu-btn"><a href ="Schedules.aspx" target="window">My Schedules</button></a></li>
		<li><button class="menu-btn"><a href ="https://www.youtube.com" target="window">Reserved Times</button></a></li>
		<li><button class="menu-btn"><a href ="https://few.io/" target="window">Registration Queues</button></a></li>
		</ul>
    </div>
    <div class="Main">
        <div class="main-box">
            <iframe width="100%" height="100%" name="window" src="ShowCatalog.aspx"></iframe>
        </div>
    </div>
    <div class="footer">
        <p>Student Schedule Planner: Ultimate Edition - Student Access</p>
    </div>
</body>
    </html>



