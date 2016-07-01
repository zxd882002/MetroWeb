USE master
GO

IF EXISTS(select * from sys.databases where name='MetroWeb')
BEGIN
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = 'MetroWeb'
ALTER DATABASE MetroWeb SET SINGLE_USER WITH ROLLBACK IMMEDIATE
DROP DATABASE MetroWeb
END
GO

CREATE DATABASE MetroWeb
GO

USE MetroWeb
CREATE TABLE Station -- ��վ��Ϣ
(
	Station_Id	INT PRIMARY KEY,
	Station_Name VARCHAR(50),
)
GO

CREATE TABLE Line -- ��·��Ϣ
(
	Line_Id INT PRIMARY KEY,
	Line_Name VARCHAR(20),
	Line_From_Station_Id INT FOREIGN KEY REFERENCES Station(Station_Id),
	Line_To_Station_Id INT FOREIGN KEY REFERENCES Station(Station_Id)
)
GO

CREATE TABLE StationLine -- վ̨��Ϣ
(
	Station_Line_Id INT PRIMARY KEY,
	Line_Id INT FOREIGN KEY REFERENCES Line(Line_Id),
	Station_Id INT FOREIGN KEY REFERENCES Station(Station_Id),
	Duration TIME,
	Cost_Arrived TIME,
	Start_Time TIME,
	End_Time TIME,
)
GO

CREATE TABLE InterChange -- վ�ڻ���
(
	Inter_Change_Id BIGINT PRIMARY KEY,
	From_Station_Line_Id INT FOREIGN KEY REFERENCES StationLine(Station_Line_Id),
	To_Station_Line_Id INT FOREIGN KEY REFERENCES StationLine(Station_Line_Id),
	Cost TIME,
)
GO

CREATE TABLE OuterChange -- վ�⻻��
(
	Outer_Change_Id BIGINT PRIMARY KEY,
	From_Station_Line_Id INT FOREIGN KEY REFERENCES StationLine(Station_Line_Id),
	To_Station_Line_Id INT FOREIGN KEY REFERENCES StationLine(Station_Line_Id),
	Cost TIME,
)
GO

CREATE VIEW V_StationLine AS
SELECT l.Line_Name, s2.Station_Name AS 'From', s3.Station_Name AS 'To', s.Station_Name, sl.Duration, sl.Cost_Arrived, sl.Start_Time, sl.End_Time
FROM StationLine sl 
INNER JOIN Line l ON l.Line_Id = sl.Line_Id
INNER JOIN Station s ON s.Station_Id = sl.Station_Id
INNER JOIN Station s2 ON l.Line_From_Station_Id = s2.Station_Id
INNER JOIN Station s3 ON l.Line_To_Station_Id = s3.Station_Id
GO