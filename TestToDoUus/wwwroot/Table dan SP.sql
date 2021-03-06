USE [db_esp]
GO
/****** Object:  Table [dbo].[tbl_todo]    Script Date: 5/16/2020 10:51:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_todo](
	[idtable] [int] IDENTITY(1,1) NOT NULL,
	[dateexpire] [datetime] NULL,
	[title] [varchar](50) NULL,
	[description] [varchar](100) NULL,
	[complete] [decimal](18, 2) NULL,
	[isdone] [int] NULL,
 CONSTRAINT [PK_tbl_todo] PRIMARY KEY CLUSTERED 
(
	[idtable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CreateTodo]    Script Date: 5/16/2020 10:51:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      <Uus Khusni>  
-- Create date: <Sabtu, 16 Mei 2020>  
-- Description: <Ambil Spesifik todo>  
-- EXEC CreateTodo '2020-05-16 08:27:24.903', 'test', 'test', 0
-- =============================================  
CREATE PROCEDURE [dbo].[CreateTodo](
	@dataexpire AS DATETIME,
	@title AS VARCHAR(50),
	@description AS VARCHAR(100),
	@complete AS DECIMAL, @ReturnCode NVARCHAR(20) OUTPUT )  
AS  
BEGIN  
 INSERT INTO tbl_todo(dateexpire, title, description, complete)
 VALUES(@dataexpire, @title, @description, @complete)

 SET @ReturnCode = 'C200' 
END 
GO
/****** Object:  StoredProcedure [dbo].[DeleteTodo]    Script Date: 5/16/2020 10:51:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      <Uus Khusni>  
-- Create date: <Sabtu, 16 Mei 2020>  
-- Description: <Ambil Spesifik todo>  
-- EXEC DeleteTodo 1
-- =============================================  
CREATE PROCEDURE [dbo].[DeleteTodo](@idtable AS INT, @ReturnCode NVARCHAR(20) OUTPUT)  
AS  
BEGIN  
 DELETE FROM tbl_todo WHERE idtable=@idtable
  SET @ReturnCode = 'C200'
END 
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 5/16/2020 10:51:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
(
@Id INT,
@ReturnCode NVARCHAR(20) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	SET @ReturnCode = 'C200'
	IF NOT EXISTS (SELECT 1 FROM Users WHERE Id = @Id)
	BEGIN
		SET @ReturnCode ='C203'
		RETURN
	END
	ELSE
	BEGIN
		DELETE FROM Users WHERE Id = @Id
		SET @ReturnCode = 'C200'
		RETURN
	END
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllToDo]    Script Date: 5/16/2020 10:51:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      <Uus Khusni>  
-- Create date: <Sabtu, 16 Mei 2020>  
-- Description: <Ambil semua data todo>  
-- EXEC GetAllToDo  
-- =============================================  
CREATE PROCEDURE [dbo].[GetAllToDo]  
AS  
BEGIN  
    SET NOCOUNT ON;  
    SELECT * FROM tbl_todo(NOLOCK) ORDER BY idtable ASC  
END 
GO
/****** Object:  StoredProcedure [dbo].[GetAllToDoById]    Script Date: 5/16/2020 10:51:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      <Uus Khusni>  
-- Create date: <Sabtu, 16 Mei 2020>  
-- Description: <Ambil Spesifik todo>  
-- EXEC GetAllToDoById(1)  
-- =============================================  
CREATE PROCEDURE [dbo].[GetAllToDoById](@idtable AS INTEGER)  
AS  
BEGIN  
    SET NOCOUNT ON;  
    SELECT * FROM tbl_todo WHERE idtable=@idtable
END 
GO
/****** Object:  StoredProcedure [dbo].[UpdateTodo]    Script Date: 5/16/2020 10:51:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      <Uus Khusni>  
-- Create date: <Sabtu, 16 Mei 2020>  
-- Description: <Ambil Spesifik todo>  
-- EXEC UpdateTodo 1, '2020-05-16 08:27:24.903', 'test', 'test', 0
-- =============================================  
CREATE PROCEDURE [dbo].[UpdateTodo](
	@idtable AS INT,
	@dataexpire AS DATETIME,
	@title AS VARCHAR(50),
	@description AS VARCHAR(100),
	@complete AS DECIMAL, @ReturnCode NVARCHAR(20) OUTPUT )  
AS  
BEGIN  
 UPDATE tbl_todo SET
	dateexpire=@dataexpire, title=@title, description=@description, complete=@complete
 WHERE idtable=@idtable
 SET @ReturnCode = 'C200'
END 
GO
/****** Object:  StoredProcedure [dbo].[UpdateTodoComplete]    Script Date: 5/16/2020 10:51:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      <Uus Khusni>  
-- Create date: <Sabtu, 16 Mei 2020>  
-- Description: <Ambil Spesifik todo>  
-- EXEC UpdateTodo 1, '2020-05-16 08:27:24.903', 'test', 'test', 0
-- =============================================  
CREATE PROCEDURE [dbo].[UpdateTodoComplete](
	@idtable AS INT,
	@complete AS DECIMAL, @ReturnCode NVARCHAR(20) OUTPUT )  
AS  
BEGIN  
 UPDATE tbl_todo SET
	complete=@complete
 WHERE idtable=@idtable
 SET @ReturnCode = 'C200'
END 
GO
/****** Object:  StoredProcedure [dbo].[UpdateTodoDone]    Script Date: 5/16/2020 10:51:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      <Uus Khusni>  
-- Create date: <Sabtu, 16 Mei 2020>  
-- Description: <Ambil Spesifik todo>  
-- EXEC UpdateTodo 1, '2020-05-16 08:27:24.903', 'test', 'test', 0
-- =============================================  
CREATE PROCEDURE [dbo].[UpdateTodoDone](
	@idtable AS INT,
	@isdone AS INT, @ReturnCode NVARCHAR(20) OUTPUT )  
AS  
BEGIN  
 UPDATE tbl_todo SET
	isdone=@isdone
 WHERE idtable=@idtable
 SET @ReturnCode = 'C200'
END 
GO
