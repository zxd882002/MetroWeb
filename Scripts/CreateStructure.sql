USE master
IF EXISTS(select * from sys.databases where name='MetroWeb')
DROP DATABASE MetroWeb
GO

CREATE DATABASE MetroWeb
GO

USE MetroWeb
CREATE TABLE Station -- 车站信息
(
	Station_Id	INT PRIMARY KEY,
	Station_Name VARCHAR(50),
)
GO

CREATE TABLE Line -- 线路信息
(
	Line_Id INT PRIMARY KEY,
	Line_Name VARCHAR(20),
	Line_Direction_Station_Id INT FOREIGN KEY REFERENCES Station(Station_Id)
)
GO

CREATE TABLE StationLine -- 站台信息
(
	Station_Line_Id INT PRIMARY KEY,
	Line_Id INT FOREIGN KEY REFERENCES Line(Line_Id),
	Station_Id INT FOREIGN KEY REFERENCES Station(Station_Id),
	Index_Number INT,
	Duration TIME,
	Cost_Arrived TIME,
	Start_Time TIME,
	End_Time TIME,
)
GO

CREATE TABLE InterChange -- 站内换乘
(
	Inter_Change_Id INT PRIMARY KEY,
	From_Station_Line_Id INT FOREIGN KEY REFERENCES StationLine(Station_Line_Id),
	To_Station_Line_Id INT FOREIGN KEY REFERENCES StationLine(Station_Line_Id),
	Cost TIME,
)
GO

CREATE TABLE OuterChange -- 站外换乘
(
	Outer_Change_Id INT PRIMARY KEY,
	From_Station_Line_Id INT FOREIGN KEY REFERENCES StationLine(Station_Line_Id),
	To_Station_Line_Id INT FOREIGN KEY REFERENCES StationLine(Station_Line_Id),
	Cost TIME,
)
GO

CREATE VIEW V_StationLine AS
SELECT l.Line_Name, s2.Station_Name AS 'Direction', s.Station_Name, sl.Index_Number, sl.Duration, sl.Cost_Arrived, sl.Start_Time, sl.End_Time
FROM StationLine sl 
INNER JOIN Line l ON l.Line_Id = sl.Line_Id
INNER JOIN Station s ON s.Station_Id = sl.Station_Id
INNER JOIN Station s2 ON l.Line_Direction_Station_Id = s2.Station_Id
GO