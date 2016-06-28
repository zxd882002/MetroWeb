USE MetroWeb
GO

Delete from Station
INSERT INTO Station VALUES
	(1,'ݷׯ'),
	(2,'�⻷·'),
	(3,'����·'),
	(4,'������԰'),
	(5,'�Ϻ���վ'),
	(6,'�·'),
	(7,'�Ϻ�������'),
	(8,'��һ�'),
	(9,'��ɽ·'),
	(10,'����·'),
	(11,'������·'),
	(12,'������·'),
	(13,'����㳡'),
	(14,'��բ·'),
	(15,'����·'),
	(16,'�Ϻ���վ'),
	(17,'��ɽ��·'),
	(18,'�ӳ�·'),
	(19,'�Ϻ���Ϸ��'),
	(20,'��ˮ·'),
	(21,'�����´�'),
	(22,'����·'),
	(23,'ͨ���´�'),
	(24,'����·'),
	(25,'�����´�'),
	(26,'������·'),
	(27,'������·'),
	(28,'����·')
GO

Delete from Line
INSERT INTO Line VALUES
	(1,'1����',1),
	(2,'1����',28)
GO

Delete from StationLine
INSERT INTO StationLine VALUES
	(1, 2, 1, 0, '0:04:05', '00:00:00', '5:30', '22:32'),
	(2, 2, 2, 1, '0:04:05', '00:02:00', '5:32', '22:34'),
	(3, 2, 3, 2, '0:04:05', '00:02:00', '5:34', '22:36'),
	(4, 2, 4, 3, '0:04:05', '00:03:00', '5:37', '22:39'),
	
	(5, 2, 5, 4, '0:04:05', '00:03:00', '5:32', '22:34'),
	(6, 2, 6, 5, '0:04:05', '00:02:00', '5:32', '22:34'),
	(7, 2, 7, 6, '0:04:05', '00:02:00', '5:32', '22:34'),
	(8, 2, 8, 7, '0:04:05', '00:02:00', '5:32', '22:34'),
	(9, 2, 9, 8, '0:04:05', '00:02:00', '5:32', '22:34'),
	(10, 2, 10, 8, '0:04:05', '00:02:00', '5:32', '22:34'),
	(11, 2, 11, 10, '0:04:05', '00:02:00', '5:32', '22:34'),
	(12, 2, 12, 11, '0:04:05', '00:02:00', '5:32', '22:34'),
	(13, 2, 13, 12, '0:04:05', '00:02:00', '5:32', '22:34'),
	(14, 2, 14, 13, '0:04:05', '00:02:00', '5:32', '22:34'),
	(15, 2, 15, 14, '0:04:05', '00:02:00', '5:32', '22:34'),
	(16, 2, 16, 15, '0:04:05', '00:02:00', '5:32', '22:34'),
	(17, 2, 17, 16, '0:04:05', '00:02:00', '5:32', '22:34'),
	(18, 2, 18, 17, '0:04:05', '00:02:00', '5:32', '22:34'),
	(19, 2, 19, 18, '0:04:05', '00:02:00', '5:32', '22:34'),
	(20, 2, 20, 19, '0:04:05', '00:02:00', '5:32', '22:34'),
	(21, 2, 21, 20, '0:04:05', '00:02:00', '5:32', '22:34'),
	(22, 2, 22, 21, '0:04:05', '00:02:00', '5:32', '22:34'),
	(23, 2, 23, 22, '0:04:05', '00:02:00', '5:32', '22:34'),
	(24, 2, 24, 23, '0:04:05', '00:02:00', '5:32', '22:34'),
	(25, 2, 25, 24, '0:04:05', '00:02:00', '5:32', '22:34'),
	(26, 2, 26, 25, '0:04:05', '00:02:00', '5:32', '22:34'),
	(27, 2, 27, 26, '0:04:05', '00:02:00', '5:32', '22:34')
GO