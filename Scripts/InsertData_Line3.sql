USE MetroWeb
GO

INSERT INTO Station VALUES
     -- (105,'上海南站'),
	(301,'石龙路'),
	(302,'龙漕路'),
	(303,'漕溪路'),
	(304,'宜山路'),
	(305,'虹桥路'),
	(306,'延安西路'),
	-- (208,'中山公园'),
	(307,'金沙江路'),
	(308,'曹杨路'),
	(309,'镇坪路'),
	(310,'中潭路'),
	--(116,'上海火车站'),
	(311,'宝山路'),
	(312,'东宝兴路'),
	(313,'虹口足球场'),
	(314,'赤峰路'),
	(315,'大柏树'),
	(316,'江湾镇'),
	(317,'殷高西路'),
	(318,'长江南路'),
	(319,'淞发路'),
	(320,'张华浜'),
	(321,'淞滨路'),
	(322,'水产路'),
	(323,'宝场路'),
	(324,'友谊路'),
	(325,'铁力路'),
	(326,'江杨北路')	 	
GO

INSERT INTO Line VALUES
	(301,'3号线',105,326),
	(302,'3号线',326,105)
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 上海南站 到 江杨北路 
	(30101, 301, 105, '0:06:30', '00:00:00', '5:25', '22:30'),
	(30102, 301, 301, '0:06:30', '00:02:00', '5:27', '22:32'),
	(30103, 301, 302, '0:06:30', '00:03:00', '5:30', '22:35'),
	(30104, 301, 303, '0:06:30', '00:02:00', '5:32', '22:37'),
	(30105, 301, 304, '0:06:30', '00:02:00', '5:34', '22:39'),
	(30106, 301, 305, '0:06:30', '00:02:00', '5:36', '22:41'),
	(30107, 301, 306, '0:06:30', '00:03:00', '5:39', '22:44'),
	(30108, 301, 208, '0:06:30', '00:02:00', '5:41', '22:46'),
	(30109, 301, 307, '0:06:30', '00:02:00', '5:43', '22:48'),
	(30110, 301, 308, '0:06:30', '00:02:00', '5:45', '22:50'),
	(30111, 301, 309, '0:06:30', '00:03:00', '5:48', '22:53'),
	(30112, 301, 310, '0:06:30', '00:02:00', '5:50', '22:55'),
	(30113, 301, 116, '0:06:30', '00:03:00', '5:53', '22:58'),
	(30114, 301, 311, '0:06:30', '00:03:00', '5:56', '23:01'),
	(30115, 301, 312, '0:06:30', '00:02:00', '5:58', '23:03'),
	(30116, 301, 313, '0:06:30', '00:03:00', '6:01', '23:06'),
	(30117, 301, 314, '0:06:30', '00:02:00', '6:03', '23:08'),
	(30118, 301, 315, '0:06:30', '00:02:00', '6:05', '23:10'),
	(30119, 301, 316, '0:06:30', '00:03:00', '6:08', '23:13'),
	(30120, 301, 317, '0:06:30', '00:02:00', '6:10', '23:15'),
	(30121, 301, 318, '0:06:30', '00:03:00', '6:13', '23:18'),
	(30122, 301, 319, '0:13:00', '00:02:00', '6:15', '23:20'),
	(30123, 301, 320, '0:13:00', '00:03:00', '6:18', '23:23'),
	(30124, 301, 321, '0:13:00', '00:02:00', '6:20', '23:25'),
	(30125, 301, 322, '0:13:00', '00:02:00', '6:22', '23:27'),
	(30126, 301, 323, '0:13:00', '00:03:00', '6:25', '23:30'),
	(30127, 301, 324, '0:13:00', '00:02:00', '6:27', '23:32'),
	(30128, 301, 325, '0:13:00', '00:02:00', '6:29', '23:34'),
	(30129, 301, 326, '0:13:00', '00:03:00', '6:32', '23:37'),
	-- 江杨北路 到 上海南站 
	(30201, 302, 326, '0:13:00', '00:00:00', '5:25', '22:35'),
	(30202, 302, 325, '0:13:00', '00:02:00', '5:27', '22:37'),
	(30203, 302, 324, '0:13:00', '00:03:00', '5:30', '22:40'),
	(30204, 302, 323, '0:13:00', '00:02:00', '5:32', '22:42'),
	(30205, 302, 322, '0:13:00', '00:03:00', '5:35', '22:45'),
	(30206, 302, 321, '0:13:00', '00:02:00', '5:37', '22:47'),
	(30207, 302, 320, '0:13:00', '00:02:00', '5:39', '22:49'),
	(30208, 302, 319, '0:13:00', '00:02:00', '5:41', '22:51'),
	(30209, 302, 318, '0:06:30', '00:03:00', '5:44', '22:54'),
	(30210, 302, 317, '0:06:30', '00:03:00', '5:47', '22:57'),
	(30211, 302, 316, '0:06:30', '00:03:00', '5:50', '23:00'),
	(30212, 302, 315, '0:06:30', '00:02:00', '5:52', '23:02'),
	(30213, 302, 314, '0:06:30', '00:02:00', '5:54', '23:04'),
	(30214, 302, 313, '0:06:30', '00:03:00', '5:57', '23:07'),
	(30215, 302, 312, '0:06:30', '00:02:00', '5:59', '23:09'),
	(30216, 302, 311, '0:06:30', '00:02:00', '6:01', '23:11'),
	(30217, 302, 116, '0:06:30', '00:04:00', '6:05', '23:15'),
	(30218, 302, 310, '0:06:30', '00:02:00', '6:07', '23:17'),
	(30219, 302, 309, '0:06:30', '00:03:00', '6:10', '23:20'),
	(30220, 302, 308, '0:06:30', '00:02:00', '6:12', '23:22'),
	(30221, 302, 307, '0:06:30', '00:02:00', '6:14', '23:24'),
	(30222, 302, 208, '0:06:30', '00:03:00', '6:17', '23:27'),
	(30223, 302, 306, '0:06:30', '00:02:00', '6:19', '23:29'),
	(30224, 302, 305, '0:06:30', '00:02:00', '6:21', '23:31'),
	(30225, 302, 304, '0:06:30', '00:02:00', '6:23', '23:33'),
	(30226, 302, 303, '0:06:30', '00:03:00', '6:26', '23:36'),
	(30227, 302, 302, '0:06:30', '00:02:00', '6:28', '23:38'),
	(30228, 302, 301, '0:06:30', '00:02:00', '6:30', '23:40'),
	(30229, 302, 105, '0:06:30', '00:02:00', '6:32', '23:42')
GO

INSERT INTO MetroTransfer VALUES
	-- 上海南站 1，3号线
	(0101030101, 10124, 30101, '0:05:00', 1),
	(0102030101, 10205, 30101, '0:05:00', 1),
	(0302010101, 30229, 10124, '0:05:00', 1),
	(0302010201, 30229, 10205, '0:05:00', 1),
	                                    
	-- 中山公园 2，3号线                
	(0201030101, 20115, 30108, '0:05:00', 1),
	(0201030201, 20115, 30222, '0:05:00', 1),
	(0202030101, 20208, 30108, '0:05:00', 1),
	(0202030201, 20208, 30222, '0:05:00', 1),
	(0301020101, 30108, 20115, '0:05:00', 1),
	(0301020201, 30108, 20208, '0:05:00', 1),
	(0302020101, 30222, 20115, '0:05:00', 1),
	(0302020201, 30222, 20208, '0:05:00', 1),

	-- 上海火车站 1，3号线
	(0101030102, 10113, 30113, '0:07:00', 0),
	(0101030202, 10113, 30217, '0:07:00', 0),
	(0102030102, 10216, 30113, '0:07:00', 0),
	(0102030202, 10216, 30217, '0:07:00', 0),
	(0301010102, 30113, 10113, '0:07:00', 0),
	(0301010202, 30113, 10216, '0:07:00', 0),
	(0302010102, 30217, 10113, '0:07:00', 0),
	(0302010202, 30217, 10216, '0:07:00', 0)
GO