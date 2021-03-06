﻿USE MetroWeb
GO

INSERT INTO Station VALUES
	(101, '莘庄', 180, 590, 205, 595),
	(102, '外环路', 220, 560, 250, 565),
	(103, '莲花路', 260, 530, 290, 535),
	(104, '锦江乐园', 300, 500, 335, 505),
	(105, '上海南站', 340, 470, 305, 475),
	(106, '漕宝路', 340, 430, 315, 440),
	(107, '上海体育馆', 380, 360, 410, 350),
	(108, '徐家汇', 420, 330, 395, 320),
	(109, '衡山路', 460, 300, 460, 315),
	(110, '常熟路', 500, 300, 500, 285),
	(111, '陕西南路', 535, 300, 535, 315),
	(112, '黄陂南路', 640, 255, 640, 270),
	(113, '人民广场', 640, 220, 670, 205),
	(114, '新闸路', 615, 180, 615, 165),
	(115, '汉中路', 590, 140, 565, 130),
	(116, '上海火车站', 535, 105, 570, 90),
	(117, '中山北路', 535, 70, 565, 55),
	(118, '延长路', 535, 35, 560, 20),
	(119, '上海马戏城', 535, 0, 570, -15),
	(120, '汶水路', 535, -35, 560, -50),
	(121, '彭浦新村', 535, -70, 565, -85),
	(122, '共康路', 535, -105, 560, -120),
	(123, '通河新村', 535, -140, 565, -155),
	(124, '呼兰路', 535, -175, 560, -190),
	(125, '共富新村', 535, -210, 565, -225),
	(126, '宝安公路', 535, -245, 565, -260),
	(127, '友谊西路', 535, -280, 565, -295),
	(128, '富锦路', 535, -315, 560, -330)
	GO

INSERT INTO Line VALUES
	(101,'1号线',128, 101, '#CC0000', 'p1:{type: ''line'', x1: 180, y1: 590, x2: 340, y2: 470, x3: 340, y3: 390, x4: 460, y4: 300, x5: 535, y5: 300, x6: 640, y6: 255, x7: 640, y7: 220, x8: 590, y8: 140, x9: 535, y9: 105, x10: 535, y10: -315}'),
	(102,'1号线',101, 128, '#CC0000', ''),
	(103,'1号线',105, 116, '#CC0000', '')
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 富锦路 到 莘庄
	(10101, 101, 128, '0:04:05', '00:00:00', '5:30', '22:30'),
	(10102, 101, 127, '0:04:05', '00:02:00', '5:32', '22:32'),
	(10103, 101, 126, '0:04:05', '00:02:00', '5:34', '22:34'),
	(10104, 101, 125, '0:04:05', '00:03:00', '5:37', '22:37'),
	(10105, 101, 124, '0:04:05', '00:03:00', '5:40', '22:40'),
	(10106, 101, 123, '0:04:05', '00:02:00', '5:42', '22:42'),
	(10107, 101, 122, '0:04:05', '00:03:00', '5:45', '22:45'),
	(10108, 101, 121, '0:04:05', '00:02:00', '5:47', '22:47'),
	(10109, 101, 120, '0:04:05', '00:03:00', '5:50', '22:50'),
	(10110, 101, 119, '0:04:05', '00:03:00', '5:53', '22:53'),
	(10111, 101, 118, '0:04:05', '00:02:00', '5:55', '22:55'),
	(10112, 101, 117, '0:04:05', '00:02:00', '5:57', '22:57'),
	(10113, 101, 116, '0:04:05', '00:03:00', '5:30', '23:00'),
	(10114, 101, 115, '0:04:05', '00:01:00', '5:31', '23:01'),
	(10115, 101, 114, '0:04:05', '00:02:00', '5:33', '23:03'),
	(10116, 101, 113, '0:04:05', '00:02:00', '5:35', '23:05'),
	(10117, 101, 112, '0:04:05', '00:03:00', '5:38', '23:08'),
	(10118, 101, 111, '0:04:05', '00:02:00', '5:40', '23:10'),
	(10119, 101, 110, '0:04:05', '00:02:00', '5:42', '23:12'),
	(10120, 101, 109, '0:04:05', '00:02:00', '5:44', '23:14'),
	(10121, 101, 108, '0:04:05', '00:02:00', '5:46', '23:16'),
	(10122, 101, 107, '0:04:05', '00:03:00', '5:49', '23:19'),
	(10123, 101, 106, '0:04:05', '00:02:00', '5:51', '23:21'),
	(10124, 101, 105, '0:04:05', '00:03:00', '5:54', '23:24'),
	(10125, 101, 104, '0:04:05', '00:03:00', '5:57', '23:27'),
	(10126, 101, 103, '0:04:05', '00:03:00', '6:00', '23:30'),
	(10127, 101, 102, '0:04:05', '00:02:00', '6:02', '23:32'),
	(10128, 101, 101, '0:04:05', '00:02:00', '6:04', '23:34'),
	-- 莘庄 到 富锦路
	(10201, 102, 101, '0:04:05', '00:00:00', '5:30', '22:32'),
	(10202, 102, 102, '0:04:05', '00:02:00', '5:32', '22:34'),
	(10203, 102, 103, '0:04:05', '00:02:00', '5:34', '22:36'),
	(10204, 102, 104, '0:04:05', '00:03:00', '5:37', '22:39'),
	(10205, 102, 105, '0:04:05', '00:03:00', '5:18', '22:42'),
	(10206, 102, 106, '0:04:05', '00:02:30', '5:20', '22:45'),
	(10207, 102, 107, '0:04:05', '00:03:00', '5:23', '22:48'),
	(10208, 102, 108, '0:04:05', '00:02:00', '5:25', '22:50'),
	(10209, 102, 109, '0:04:05', '00:02:00', '5:27', '22:52'),
	(10210, 102, 110, '0:04:05', '00:02:00', '5:29', '22:54'),
	(10211, 102, 111, '0:04:05', '00:02:00', '5:31', '22:56'),
	(10212, 102, 112, '0:04:05', '00:02:30', '5:34', '22:58'),
	(10213, 102, 113, '0:04:05', '00:02:30', '5:37', '23:01'),
	(10214, 102, 114, '0:04:05', '00:01:30', '5:38', '23:03'),
	(10215, 102, 115, '0:04:05', '00:02:00', '5:40', '23:05'),
	(10216, 102, 116, '0:04:05', '00:03:00', '5:43', '23:08'),
	(10217, 102, 117, '0:04:05', '00:02:00', '5:45', '23:10'),
	(10218, 102, 118, '0:04:05', '00:03:00', '5:48', '23:13'),
	(10219, 102, 119, '0:04:05', '00:02:00', '5:50', '23:15'),
	(10220, 102, 120, '0:04:05', '00:02:00', '5:52', '23:17'),
	(10221, 102, 121, '0:04:05', '00:03:00', '5:55', '23:20'),
	(10222, 102, 122, '0:04:05', '00:03:00', '5:58', '23:23'),
	(10223, 102, 123, '0:04:05', '00:02:00', '6:00', '23:25'),
	(10224, 102, 124, '0:04:05', '00:02:30', '6:03', '23:27'),
	(10225, 102, 125, '0:04:05', '00:02:30', '6:05', '23:30'),
	(10226, 102, 126, '0:04:05', '00:03:00', '6:08', '23:33'),
	(10227, 102, 127, '0:04:05', '00:02:00', '6:10', '23:35'),
	(10228, 102, 128, '0:04:05', '00:02:00', '6:12', '23:37'),
	-- 上海南站 到 上海火车站
	(10301, 103, 105, '0:04:05', '00:00:00', '4:55', '22:42'),
	(10302, 103, 106, '0:04:05', '00:02:30', '4:57', '22:45'),
	(10303, 103, 107, '0:04:05', '00:03:00', '5:00', '22:48'),
	(10304, 103, 108, '0:04:05', '00:02:00', '5:02', '22:50'),
	(10305, 103, 109, '0:04:05', '00:02:00', '5:04', '22:52'),
	(10306, 103, 110, '0:04:05', '00:02:00', '5:06', '22:54'),
	(10307, 103, 111, '0:04:05', '00:02:00', '5:08', '22:56'),
	(10308, 103, 112, '0:04:05', '00:02:30', '5:11', '22:58'),
	(10309, 103, 113, '0:04:05', '00:03:00', '5:14', '23:01'),
	(10310, 103, 114, '0:04:05', '00:01:30', '5:15', '23:03'),
	(10311, 103, 115, '0:04:05', '00:02:00', '5:17', '23:05'),
	(10312, 103, 116, '0:04:05', '00:02:30', '5:19', '23:08')
GO