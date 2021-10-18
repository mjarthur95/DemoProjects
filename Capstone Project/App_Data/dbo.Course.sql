CREATE TABLE [dbo].[Course] (
    [course_columnID] INT          NOT NULL,
    [deptID]          VARCHAR (4)  NOT NULL,
    [courseID]        INT          NOT NULL,
    [courseTitle]     VARCHAR (50) NOT NULL,
    [jack] NCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([course_columnID] ASC)
);

