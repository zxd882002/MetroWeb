﻿USE MetroWeb
GO

INSERT INTO Station VALUES
	(201, '徐泾东', -140, 265, -140, 250),
	(202, '虹桥火车站', -70, 270, -70, 255),
	(203, '虹桥2号航站楼', 0, 270, 0, 285),
	(204, '淞虹路', 70, 220, 95, 235),
	(205, '北新泾', 140, 220, 165, 235),
	(206, '威宁路', 210, 220, 235, 235),
	(207, '娄山关路', 280, 220, 310, 235),
	(208, '中山公园', 350, 220, 380, 235),
	(209, '江苏路', 420, 220, 445, 235),
	(210, '静安寺', 500, 220, 520, 235),
	(211, '南京西路', 550, 220, 580, 235),
  --(113,'人民广场'),
	(212, '南京东路', 720, 220, 750, 235),
	(213, '陆家嘴', 790, 220, 815, 220),
	(214, '东昌路', 820, 250, 795, 255),
	(215, '世纪大道', 850, 280, 850, 295),
	(216, '上海科技馆', 880, 310, 920, 310),
	(217, '世纪公园', 910, 340, 945, 340),
	(218, '龙阳路', 960, 390, 930, 390),
	(219, '张江高科', 1010, 390, 1010, 405),
	(220, '金科路', 1080, 390, 1080, 405),
	(221, '广兰路', 1150, 390, 1150, 405),
	(222, '唐镇', 1220, 390, 1220, 405),
	(223, '创新中路', 1290, 390, 1290, 375),
	(224, '华夏东路', 1290, 440, 1250, 440),
	(225, '川沙', 1290, 490, 1265, 490),
	(226, '凌空路', 1290, 540, 1260, 540),
	(227, '远东大道', 1290, 590, 1250, 590),
	(228, '海天三路', 1290, 640, 1250, 640),
	(229, '浦东国际机场', 1290, 690, 1240, 690)
GO

INSERT INTO Line VALUES
	(201,'2号线',221,201, '#009900', 'p1: { type: ''line'', x1: -140, y1: 265, x2: 5, y2: 265, x3: 70, y3: 220, x4: 790, y4: 220, x5: 960, y5: 390, x6: 1290, y6: 390, x7: 1290, y7: 690}'),
	(202,'2号线',201,221, '#009900', ''),
	(203,'2号线',229,221, '#009900', ''),
	(204,'2号线',221,229, '#009900', '')
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 广兰路 到 徐泾东
	(20101, 201, 221, '0:03:40', '00:00:00', '5:30', '22:50'),
	(20102, 201, 220, '0:03:40', '00:03:00', '5:33', '22:53'),
	(20103, 201, 219, '0:03:40', '00:02:00', '5:35', '22:55'),
	(20104, 201, 218, '0:03:40', '00:04:00', '5:21', '23:59'),
	(20105, 201, 217, '0:03:40', '00:01:30', '5:22', '23:01'),
	(20106, 201, 216, '0:03:40', '00:03:00', '5:25', '23:04'),
	(20107, 201, 215, '0:03:40', '00:03:00', '5:28', '23:07'),
	(20108, 201, 214, '0:03:40', '00:02:30', '5:30', '23:10'),
	(20109, 201, 213, '0:03:40', '00:02:00', '5:32', '23:12'),
	(20110, 201, 212, '0:03:40', '00:03:00', '5:35', '23:15'),
	(20111, 201, 113, '0:03:40', '00:03:00', '5:38', '23:18'),
	(20112, 201, 211, '0:03:40', '00:02:30', '5:40', '23:21'),
	(20113, 201, 210, '0:03:40', '00:02:30', '5:42', '23:24'),
	(20114, 201, 209, '0:03:40', '00:02:30', '5:45', '23:26'),
	(20115, 201, 208, '0:03:40', '00:03:00', '5:48', '23:29'),
	(20116, 201, 207, '0:03:40', '00:02:30', '5:50', '23:32'),
	(20117, 201, 206, '0:03:40', '00:03:00', '5:53', '23:35'),
	(20118, 201, 205, '0:03:40', '00:02:30', '5:55', '23:38'),
	(20119, 201, 204, '0:03:40', '00:02:30', '5:58', '23:40'),
	(20120, 201, 203, '0:07:20', '00:07:00', '6:05', '23:47'),
	(20121, 201, 202, '0:07:20', '00:02:00', '6:07', '23:49'),
	(20122, 201, 201, '0:07:20', '00:02:00', '6:09', '23:51'),
	-- 徐泾东 到 广兰路 
	(20201, 202, 201, '0:07:20', '00:00:00', '5:30', '22:45'),
	(20202, 202, 202, '0:07:20', '00:03:00', '5:33', '22:48'),
	(20203, 202, 203, '0:07:20', '00:02:30', '5:35', '22:50'),
	(20204, 202, 204, '0:03:40', '00:07:00', '5:42', '22:57'),
	(20205, 202, 205, '0:03:40', '00:02:00', '5:44', '22:59'),
	(20206, 202, 206, '0:03:40', '00:02:00', '5:46', '23:01'),
	(20207, 202, 207, '0:03:40', '00:03:00', '5:49', '23:04'),
	(20208, 202, 208, '0:03:40', '00:03:00', '5:52', '23:07'),
	(20209, 202, 209, '0:03:40', '00:02:00', '5:54', '23:09'),
	(20210, 202, 210, '0:03:40', '00:03:00', '5:57', '23:12'),
	(20211, 202, 211, '0:03:40', '00:02:00', '5:59', '23:14'),
	(20212, 202, 113, '0:03:40', '00:03:00', '6:02', '23:17'),
	(20213, 202, 212, '0:03:40', '00:02:00', '6:04', '23:19'),
	(20214, 202, 213, '0:03:40', '00:03:00', '6:07', '23:22'),
	(20215, 202, 214, '0:03:40', '00:02:00', '6:09', '23:24'),
	(20216, 202, 215, '0:03:40', '00:02:00', '6:11', '23:26'),
	(20217, 202, 216, '0:03:40', '00:03:00', '6:14', '23:29'),
	(20218, 202, 217, '0:03:40', '00:02:00', '6:16', '23:31'),
	(20219, 202, 218, '0:03:40', '00:02:00', '6:18', '23:33'),
	(20220, 202, 219, '0:03:40', '00:04:00', '6:22', '23:37'),
	(20221, 202, 220, '0:03:40', '00:03:00', '6:25', '23:40'),
	(20222, 202, 221, '0:03:40', '00:03:00', '6:27', '23:42'),
	-- 浦东国际机场 到 广兰路 
	(20301, 203, 229, '0:06:50', '00:00:00', '6:00', '22:00'),
	(20302, 203, 228, '0:06:50', '00:03:00', '6:03', '22:03'),
	(20303, 203, 227, '0:06:50', '00:07:00', '6:10', '22:10'),
	(20304, 203, 226, '0:06:50', '00:08:00', '6:15', '22:15'),
	(20305, 203, 225, '0:06:50', '00:03:00', '6:18', '22:18'),
	(20306, 203, 224, '0:06:50', '00:05:00', '6:23', '22:23'),
	(20307, 203, 223, '0:06:50', '00:03:00', '6:26', '22:26'),
	(20308, 203, 222, '0:06:50', '00:03:00', '6:29', '22:29'),
	(20309, 203, 221, '0:06:50', '00:05:00', '6:34', '22:34'),
	-- 广兰路 到 浦东国际机场 
	(20401, 204, 221, '0:06:50', '00:00:00', '6:00', '22:00'),
	(20402, 204, 222, '0:06:50', '00:04:00', '6:04', '22:04'),
	(20403, 204, 223, '0:06:50', '00:04:00', '6:08', '22:08'),
	(20404, 204, 224, '0:06:50', '00:03:00', '6:11', '22:11'),
	(20405, 204, 225, '0:06:50', '00:04:00', '6:15', '22:15'),
	(20406, 204, 226, '0:06:50', '00:04:00', '6:19', '22:19'),
	(20407, 204, 227, '0:06:50', '00:05:00', '6:24', '22:24'),
	(20408, 204, 228, '0:06:50', '00:07:00', '6:31', '22:31'),
	(20409, 204, 229, '0:06:50', '00:03:00', '6:34', '22:34')
GO

INSERT INTO MetroTransfer VALUES
	-- 人民广场 1，2号线
	(0101020101, 10116, 20111, '0:03:00', 1),
	(0101020201, 10116, 20212, '0:03:00', 1),	
	(0102020101, 10213, 20111, '0:03:00', 1),
	(0102020201, 10213, 20212, '0:03:00', 1),
	(0201010101, 20111, 10116, '0:03:00', 1),
	(0201010201, 20111, 10213, '0:03:00', 1),	
	(0202010101, 20212, 10116, '0:03:00', 1),
	(0202010201, 20212, 10213, '0:03:00', 1),
	-- 广兰路 2号线
	(0202020401, 20222, 20401, '0:00:00', 1),
	(0203020102, 20309, 20101, '0:00:00', 1)
GO