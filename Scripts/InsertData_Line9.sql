﻿USE MetroWeb
GO

INSERT INTO Station VALUES
  (901, '杨高中路', 910, 280, 910, 295),
--(215, '世纪大道'),
  (902, '商城路', 790, 280, 790, 295),
  (903, '小南门', 730, 330, 730, 345),
--(810, '陆家浜路'),
  (904, '马当路', 630, 330, 630, 345),
  (905, '打浦桥', 580, 330, 580, 345),
  (906, '嘉善路', 530, 330, 537, 345),
--(710, '肇嘉浜路'),
--(108, '徐家汇'),
--(304, '宜山路'),
  (907, '桂林路', 280, 340, 280, 355),
  (908, '漕河泾开发区', 210, 340, 210, 355),
  (909, '合川路', 140, 340, 140, 355),
  (910, '星中路', 70, 340, 70, 355),
  (911, '七宝', 0, 340, 0, 355),
  (912, '中春路', -70, 340, -70, 355),
  (913, '九亭', -140, 340, -140, 355),
  (914, '泗泾', -210, 340, -210, 325),
  (915, '佘山', -210, 375, -230, 375),
  (916, '洞泾', -210, 410, -230, 410),
  (917, '松江大学城', -210, 445, -250, 445),
  (918, '松江新城', -210, 480, -245, 480),
  (919, '松江体育中心', -210, 515, -255, 515),
  (920, '醉白池', -210, 550, -240, 550),
  (921, '松江南站', -210, 585, -245, 585)
GO

INSERT INTO Line VALUES
	(901,'9号线',901,921, '#95D3DB', 'p1: {type: ''line'', x1: 910, y1: 280, x2: 790, y2: 280, x3: 730, y3: 330, x4: 420, y4: 330, x5: 350, y5: 340, x6: -210, y6: 340, x7: -210, y7: 585}'),
	(902,'9号线',921,901, '', '')
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 杨高中路 到 松江南站
	(90101, 901, 901, '00:05:00', '00:00:00', '5:30', '22:30'),
	(90102, 901, 215, '00:05:00', '00:04:00', '5:34', '22:34'),
	(90103, 901, 902, '00:05:00', '00:02:00', '5:36', '22:36'),
	(90104, 901, 903, '00:05:00', '00:04:00', '5:40', '22:40'),
	(90105, 901, 810, '00:05:00', '00:03:00', '5:43', '22:43'),
	(90106, 901, 904, '00:05:00', '00:02:00', '5:45', '22:45'),
	(90107, 901, 905, '00:05:00', '00:02:00', '5:47', '22:47'),
	(90108, 901, 906, '00:05:00', '00:02:00', '5:49', '22:49'),
	(90109, 901, 710, '00:05:00', '00:02:00', '5:51', '22:51'),
	(90110, 901, 108, '00:05:00', '00:03:00', '5:54', '22:54'),
	(90111, 901, 304, '00:05:00', '00:03:00', '5:57', '22:57'),
	(90112, 901, 907, '00:05:00', '00:03:00', '6:00', '23:00'),
	(90113, 901, 908, '00:05:00', '00:03:00', '6:03', '23:03'),
	(90114, 901, 909, '00:05:00', '00:02:00', '6:05', '23:05'),
	(90115, 901, 910, '00:05:00', '00:03:00', '6:08', '23:08'),
	(90116, 901, 911, '00:05:00', '00:03:00', '6:11', '23:11'),
	(90117, 901, 912, '00:05:00', '00:03:00', '6:14', '23:14'),
	(90118, 901, 913, '00:05:00', '00:04:00', '6:18', '23:18'),
	(90119, 901, 914, '00:05:00', '00:06:00', '6:24', '23:24'),
	(90120, 901, 915, '00:05:00', '00:05:00', '6:29', '23:29'),
	(90121, 901, 916, '00:05:00', '00:03:00', '6:32', '23:32'),
	(90122, 901, 917, '00:05:00', '00:04:00', '6:36', '23:36'),
	(90123, 901, 918, '00:05:00', '00:04:00', '6:40', '23:40'),
	(90124, 901, 919, '00:05:00', '00:03:00', '6:43', '23:43'),
	(90125, 901, 920, '00:05:00', '00:03:00', '6:46', '23:46'),
	(90126, 901, 921, '00:05:00', '00:03:00', '6:49', '23:49'),

	-- 松江南站 到 杨高中路
	(90201, 902, 921, '00:05:00', '00:00:00', '5:40', '21:50'),
	(90202, 902, 920, '00:05:00', '00:04:00', '5:44', '21:54'),
	(90203, 902, 919, '00:05:00', '00:03:00', '5:47', '21:57'),
	(90204, 902, 918, '00:05:00', '00:03:00', '5:50', '22:00'),
	(90205, 902, 917, '00:05:00', '00:03:00', '5:53', '22:03'),
	(90206, 902, 916, '00:05:00', '00:05:00', '5:58', '22:08'),
	(90207, 902, 915, '00:05:00', '00:03:00', '6:01', '22:11'),
	(90208, 902, 914, '00:05:00', '00:04:00', '6:05', '22:15'),
	(90209, 902, 913, '00:05:00', '00:07:00', '6:12', '22:22'),
	(90210, 902, 912, '00:05:00', '00:04:00', '5:40', '22:26'),
	(90211, 902, 911, '00:05:00', '00:02:00', '5:42', '22:28'),
	(90212, 902, 910, '00:05:00', '00:03:00', '5:45', '22:31'),
	(90213, 902, 909, '00:05:00', '00:03:00', '5:48', '22:34'),
	(90214, 902, 908, '00:05:00', '00:03:00', '5:51', '22:37'),
	(90215, 902, 907, '00:05:00', '00:03:00', '5:54', '22:40'),
	(90216, 902, 304, '00:05:00', '00:03:00', '5:57', '22:44'),
	(90217, 902, 108, '00:05:00', '00:04:00', '6:01', '22:47'),
	(90218, 902, 710, '00:05:00', '00:02:00', '6:03', '22:49'),
	(90219, 902, 906, '00:05:00', '00:02:00', '6:05', '22:52'),
	(90220, 902, 905, '00:05:00', '00:02:00', '6:07', '22:54'),
	(90221, 902, 904, '00:05:00', '00:03:00', '6:10', '22:56'),
	(90222, 902, 810, '00:05:00', '00:02:00', '6:12', '22:58'),
	(90223, 902, 903, '00:05:00', '00:03:00', '6:15', '23:01'),
	(90224, 902, 902, '00:05:00', '00:03:00', '6:18', '23:05'),
	(90225, 902, 215, '00:05:00', '00:03:00', '6:21', '23:07'),
	(90226, 902, 901, '00:05:00', '00:03:00', '6:24', '23:10')

GO

INSERT INTO MetroTransfer VALUES
	-- 世纪大道 2，9号线
	(0201090101, 20107, 90102, '00:02:00', 1),
	(0201090201, 20107, 90225, '00:02:00', 1),
	(0202090101, 20216, 90102, '00:02:00', 1),
	(0202090201, 20216, 90225, '00:02:00', 1),
	(0901020101, 90102, 20107, '00:02:00', 1),
	(0901020201, 90102, 20216, '00:02:00', 1),
	(0902020101, 90225, 20107, '00:02:00', 1),
	(0902020201, 90225, 20216, '00:02:00', 1),

	-- 世纪大道 4，9号线
	(0401090101, 40112, 90102, '00:02:00', 1),
	(0401090201, 40112, 90225, '00:02:00', 1),
	(0402090101, 40215, 90102, '00:02:00', 1),
	(0402090201, 40215, 90225, '00:02:00', 1),
	(0901040101, 90102, 40112, '00:02:00', 1),
	(0901040201, 90102, 40215, '00:02:00', 1),
	(0902040101, 90225, 40112, '00:02:00', 1),
	(0902040201, 90225, 40215, '00:02:00', 1),

	-- 世纪大道 6，9号线
	(0601090101, 60117, 90102, '00:00:00', 1),
	(0601090201, 60117, 90225, '00:00:00', 1),
	(0602090101, 60212, 90102, '00:00:00', 1),
	(0602090201, 60212, 90225, '00:00:00', 1),
	(0901060101, 90102, 60117, '00:00:00', 1),
	(0901060201, 90102, 60212, '00:00:00', 1),
	(0902060101, 90225, 60117, '00:00:00', 1),
	(0902060201, 90225, 60212, '00:00:00', 1),
	
	-- 陆家浜路 8，9号线
	(0801090101, 80113, 90105, '00:01:00', 1),
	(0801090201, 80113, 90222, '00:01:00', 1),
	(0802090101, 80218, 90105, '00:01:00', 1),
	(0802090201, 80218, 90222, '00:01:00', 1),
	(0901080101, 90105, 80113, '00:01:00', 1),
	(0901080201, 90105, 80218, '00:01:00', 1),
	(0902080101, 90222, 80113, '00:01:00', 1),
	(0902080201, 90222, 80218, '00:01:00', 1),

	-- 肇嘉浜路 7，9号线
	(0701090101, 70113, 90109, '00:01:00', 1),
	(0701090201, 70113, 90218, '00:01:00', 1),
	(0702090101, 70221, 90109, '00:01:00', 1),
	(0702090201, 70221, 90218, '00:01:00', 1),
	(0901070101, 90109, 70113, '00:01:00', 1),
	(0901070201, 90109, 70221, '00:01:00', 1),
	(0902070101, 90218, 70113, '00:01:00', 1),
	(0902070201, 90218, 70221, '00:01:00', 1),

	-- 徐家汇 1，9号线
	(0101090101, 10121, 90110, '00:03:00', 1),
	(0101090201, 10121, 90217, '00:03:00', 1),
	(0102090101, 10208, 90110, '00:03:00', 1),
	(0102090201, 10208, 90217, '00:03:00', 1),
	(0901010101, 90110, 10121, '00:03:00', 1),
	(0901010201, 90110, 10208, '00:03:00', 1),
	(0902010101, 90217, 10121, '00:03:00', 1),
	(0902010201, 90217, 10208, '00:03:00', 1),

	-- 宜山路 3，9号线
	(0301090101, 30105, 90111, '00:03:00', 1),
	(0301090201, 30105, 90216, '00:03:00', 1),
	(0302090101, 30225, 90111, '00:03:00', 1),
	(0302090201, 30225, 90216, '00:03:00', 1),
	(0901030101, 90111, 30105, '00:03:00', 1),
	(0901030201, 90111, 30225, '00:03:00', 1),
	(0902030101, 90216, 30105, '00:03:00', 1),
	(0902030201, 90216, 30225, '00:03:00', 1),
	
	-- 宜山路 4，9号线
	(0401090102, 40101, 90111, '00:03:00', 1),
	(0401090202, 40101, 90216, '00:03:00', 1),
	(0402090102, 40226, 90111, '00:03:00', 1),
	(0402090202, 40226, 90216, '00:03:00', 1),
	(0901040102, 90111, 40101, '00:03:00', 1),
	(0901040202, 90111, 40226, '00:03:00', 1),
	(0902040102, 90216, 40101, '00:03:00', 1),
	(0902040202, 90216, 40226, '00:03:00', 1)

GO