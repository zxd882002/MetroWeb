USE MetroWeb
GO

INSERT INTO Station VALUES
  (1301, '金运路'),
  (1302, '金沙江西路'),
  (1303, '丰庄'),
  (1304, '祁连山南路'),
  (1305, '真北路'),
  (1306, '大渡河路'),
--(307 , '金沙江路'),
--(1113, '隆德路'),
  (1307, '武宁路'),
--(712 , '长寿路'),
  (1308, '江宁路'),
--(115 , '汉中路'),
  (1309, '自然博物馆'),
--(211 , '南京西路'),
  (1310, '淮海中路'),
--(1012, '新天地'),
--(904 , '马当路'),
  (1311, '世博会博物馆'),
  (1312, '世博大道')  
GO

INSERT INTO Line VALUES
	(1301,'13号线',1301,1312),
	(1302,'13号线',1312,1301)
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 金运路 到 世博大道
	(130101, 1301, 1301, '00:06:00', '00:00:00', '5:50', '22:11'),
	(130102, 1301, 1302, '00:06:00', '00:02:00', '5:52', '22:13'),
	(130103, 1301, 1303, '00:06:00', '00:04:00', '5:56', '22:17'),
	(130104, 1301, 1304, '00:06:00', '00:03:00', '5:59', '22:20'),
	(130105, 1301, 1305, '00:06:00', '00:02:00', '6:01', '22:22'),
	(130106, 1301, 1306, '00:06:00', '00:03:00', '6:04', '22:25'),
	(130107, 1301, 307, '00:06:00', '00:04:00', '6:08', '22:29'),
	(130108, 1301, 1113, '00:06:00', '00:02:00', '6:10', '22:31'),
	(130109, 1301, 1307, '00:06:00', '00:03:00', '6:13', '22:34'),
	(130110, 1301, 712, '00:06:00', '00:02:00', '6:15', '22:36'),
	(130111, 1301, 1308, '00:06:00', '00:02:00', '6:17', '22:38'),
	(130112, 1301, 115, '00:06:00', '00:03:00', '6:20', '22:41'),
	(130113, 1301, 1309, '00:06:00', '00:01:00', '6:21', '22:42'),
	(130114, 1301, 211, '00:06:00', '00:03:00', '6:24', '22:45'),
	(130115, 1301, 1310, '00:06:00', '00:02:00', '6:26', '22:47'),
	(130116, 1301, 1012, '00:06:00', '00:03:00', '6:29', '22:50'),
	(130117, 1301, 904, '00:06:00', '00:02:00', '6:31', '22:52'),
	(130118, 1301, 1311, '00:06:00', '00:02:00', '6:33', '22:54'),
	(130119, 1301, 1312, '00:06:00', '00:03:00', '6:36', '22:57'),

	-- 世博大道 到 金运路
	(130201, 1302, 1312, '00:06:00', '00:00:00', '6:00', '22:08'),
	(130202, 1302, 1311, '00:06:00', '00:03:00', '6:03', '22:11'),
	(130203, 1302, 904, '00:06:00', '00:02:30', '6:05', '22:14'),
	(130204, 1302, 1012, '00:06:00', '00:01:30', '6:07', '22:15'),
	(130205, 1302, 1310, '00:06:00', '00:03:00', '6:10', '22:18'),
	(130206, 1302, 211, '00:06:00', '00:02:30', '6:12', '22:21'),
	(130207, 1302, 1309, '00:06:00', '00:02:00', '6:14', '22:23'),
	(130208, 1302, 115, '00:06:00', '00:02:00', '6:16', '22:25'),
	(130209, 1302, 1308, '00:06:00', '00:03:00', '6:19', '22:28'),
	(130210, 1302, 712, '00:06:00', '00:02:00', '6:12', '22:30'),
	(130211, 1302, 1307, '00:06:00', '00:02:00', '6:14', '22:32'),
	(130212, 1302, 1113, '00:06:00', '00:02:30', '6:17', '22:34'),
	(130213, 1302, 307, '00:06:00', '00:03:00', '6:20', '22:37'),
	(130214, 1302, 1306, '00:06:00', '00:03:00', '6:23', '22:40'),
	(130215, 1302, 1305, '00:06:00', '00:03:00', '6:26', '22:43'),
	(130216, 1302, 1304, '00:06:00', '00:02:30', '6:28', '22:46'),
	(130217, 1302, 1303, '00:06:00', '00:02:30', '6:31', '22:48'),
	(130218, 1302, 1302, '00:06:00', '00:03:00', '6:34', '22:51'),
	(130219, 1302, 1301, '00:06:00', '00:02:30', '6:36', '22:54')

GO

INSERT INTO InterChange VALUES
	-- 金沙江路 3，13号线
	(0301130101, 30109, 130107, '00:03:00'),
	(0301130201, 30109, 130213, '00:03:00'),
	(0302130101, 30221, 130107, '00:03:00'),
	(0302130201, 30221, 130213, '00:03:00'),
	(1301030101, 130107, 30109, '00:03:00'),
	(1301030201, 130107, 30221, '00:03:00'),
	(1302030101, 130213, 30109, '00:03:00'),
	(1302030201, 130213, 30221, '00:03:00'),
	
	-- 金沙江路 4，13号线
	(0401130101, 40123, 130107, '00:03:00'),
	(0401130201, 40123, 130213, '00:03:00'),
	(0402130101, 40204, 130107, '00:03:00'),
	(0402130201, 40204, 130213, '00:03:00'),
	(1301040101, 130107, 40123, '00:03:00'),
	(1301040201, 130107, 40204, '00:03:00'),
	(1302040101, 130213, 40123, '00:03:00'),
	(1302040201, 130213, 40204, '00:03:00'),

	-- 隆德路 11，13号线
	(1101130101, 110117, 130108, '00:01:00'),
	(1101130201, 110117, 130212, '00:01:00'),
	(1103130101, 110317, 130108, '00:01:00'),
	(1103130201, 110317, 130212, '00:01:00'),
	(1301110101, 130108, 110117, '00:01:00'),
	(1301110301, 130108, 110317, '00:01:00'),
	(1302110101, 130212, 110117, '00:01:00'),
	(1302110301, 130212, 110317, '00:01:00'),
	(1104130101, 110415, 130108, '00:01:00'),
	(1104130201, 110415, 130212, '00:01:00'),
	(1105130101, 110519, 130108, '00:01:00'),
	(1105130201, 110519, 130212, '00:01:00'),
	(1301110401, 130108, 110415, '00:01:00'),
	(1301110501, 130108, 110519, '00:01:00'),
	(1302110401, 130212, 110415, '00:01:00'),
	(1302110501, 130212, 110519, '00:01:00'),

	-- 长寿路 7，13号线
	(0701130101, 70117, 130110, '00:02:00'),
	(0701130201, 70117, 130210, '00:02:00'),
	(0702130101, 70217, 130110, '00:02:00'),
	(0702130201, 70217, 130210, '00:02:00'),
	(1301070101, 130110, 70117, '00:02:00'),
	(1301070201, 130110, 70217, '00:02:00'),
	(1302070101, 130210, 70117, '00:02:00'),
	(1302070201, 130210, 70217, '00:02:00'),

	-- 汉中路 1，13号线
	(0101130101, 10114, 130112, '00:02:00'),
	(0101130201, 10114, 130208, '00:02:00'),
	(0102130101, 10215, 130112, '00:02:00'),
	(0102130201, 10215, 130208, '00:02:00'),
	(1301010101, 130112, 10114, '00:02:00'),
	(1301010201, 130112, 10215, '00:02:00'),
	(1302010101, 130208, 10114, '00:02:00'),
	(1302010201, 130208, 10215, '00:02:00'),

	-- 汉中路 12，13号线
	(1201130101, 120117, 130112, '00:01:00'),
	(1201130201, 120117, 130208, '00:01:00'),
	(1202130101, 120216, 130112, '00:01:00'),
	(1202130201, 120216, 130208, '00:01:00'),
	(1301120101, 130112, 120117, '00:01:00'),
	(1301120201, 130112, 120216, '00:01:00'),
	(1302120101, 130208, 120117, '00:01:00'),
	(1302120201, 130208, 120216, '00:01:00'),

	-- 新天地 10，13号线
	(1001130101, 100116, 130116, '00:01:00'),
	(1001130201, 100116, 130204, '00:01:00'),
	(1002130101, 100216, 130116, '00:01:00'),
	(1002130201, 100216, 130204, '00:01:00'),
	(1301100101, 130116, 100116, '00:01:00'),
	(1301100201, 130116, 100216, '00:01:00'),
	(1302100101, 130204, 100116, '00:01:00'),
	(1302100201, 130204, 100216, '00:01:00'),
	(1003130101, 100312, 130116, '00:01:00'),
	(1003130201, 100312, 130204, '00:01:00'),
	(1004130101, 100413, 130116, '00:01:00'),
	(1004130201, 100413, 130204, '00:01:00'),
	(1301100301, 130116, 100312, '00:01:00'),
	(1301100401, 130116, 100413, '00:01:00'),
	(1302100301, 130204, 100312, '00:01:00'),
	(1302100401, 130204, 100413, '00:01:00'),

	-- 马当路 9，13号线
	(0901130101, 90106, 130117, '00:02:00'),
	(0901130201, 90106, 130203, '00:02:00'),
	(0902130101, 90201, 130117, '00:02:00'),
	(0902130201, 90201, 130203, '00:02:00'),
	(1301090101, 130117, 90106, '00:02:00'),
	(1301090201, 130117, 90201, '00:02:00'),
	(1302090101, 130203, 90106, '00:02:00'),
	(1302090201, 130203, 90201, '00:02:00')
GO

INSERT INTO OuterChange VALUES
	-- 南京西路 2，13号线
	(0201130101, 20112, 130114, '00:05:00'),
	(0201130201, 20112, 130206, '00:05:00'),
	(0202130101, 20211, 130114, '00:05:00'),
	(0202130201, 20211, 130206, '00:05:00'),
	(1301020101, 130114, 20112, '00:05:00'),
	(1301020201, 130114, 20211, '00:05:00'),
	(1302020101, 130206, 20112, '00:05:00'),
	(1302020201, 130206, 20211, '00:05:00'),

	-- 南京西路 12，13号线
	(1201130101, 120118, 130114, '00:07:00'),
	(1201130201, 120118, 130206, '00:07:00'),
	(1202130101, 120215, 130114, '00:07:00'),
	(1202130201, 120215, 130206, '00:07:00'),
	(1301120101, 130114, 120118, '00:07:00'),
	(1301120201, 130114, 120215, '00:07:00'),
	(1302120101, 130206, 120118, '00:07:00'),
	(1302120201, 130206, 120215, '00:07:00')
GO