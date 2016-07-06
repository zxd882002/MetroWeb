﻿USE MetroWeb
GO

INSERT INTO Station VALUES
  (1001, '新江湾城'),
  (1002, '殷高东路'),
  (1003, '三门路'),
  (1004, '江湾体育场'),
  (1005, '五角场'),
  (1006, '国权路'),
  (1007, '同济大学'),
--(817 , '四平路'),
  (1008, '邮电新村'),
--(414 , '海伦路'),
  (1009, '四川北路'),
  (1010, '天潼路'),
--(212 , '南京东路'),
  (1011, '豫园'),
--(811 , '老西门'),
  (1012, '新天地'),
--(111 , '陕西南路'),
  (1013, '上海图书馆'),
  (1014, '交通大学'),
--(305 , '虹桥路'),
  (1015, '宋园路'),
  (1016, '伊犁路'),
  (1017, '水城路'),
  (1018, '龙溪路'),
  (1019, '上海动物园'),
  (1020, '虹桥1号航站楼'),
--(203 , '虹桥2号航站楼'),
--(202 , '虹桥火车站'),
  (1021, '龙柏新村'),
  (1022, '紫藤路'),
  (1023, '航中路')
GO

INSERT INTO Line VALUES
	(1001,'10号线',1001,1023),
	(1002,'10号线',1001,202),
	(1003,'10号线',1023,1001),
	(1004,'10号线',202,1001)
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 新江湾城 到 航中路
	(100101, 1001, 1001, '00:05:00', '00:00:00', '5:30', '22:00'),
	(100102, 1001, 1002, '00:05:00', '00:01:00', '5:31', '22:01'),
	(100103, 1001, 1003, '00:05:00', '00:02:00', '5:33', '22:03'),
	(100104, 1001, 1004, '00:05:00', '00:02:30', '5:35', '22:06'),
	(100105, 1001, 1005, '00:05:00', '00:01:30', '5:37', '22:07'),
	(100106, 1001, 1006, '00:05:00', '00:02:00', '5:39', '22:09'),
	(100107, 1001, 1007, '00:05:00', '00:02:00', '5:41', '22:11'),
	(100108, 1001, 817, '00:05:00', '00:02:00', '5:43', '22:13'),
	(100109, 1001, 1008, '00:05:00', '00:02:00', '5:45', '22:15'),
	(100110, 1001, 414, '00:05:00', '00:02:00', '5:47', '22:17'),
	(100111, 1001, 1009, '00:05:00', '00:02:00', '5:49', '22:19'),
	(100112, 1001, 1010, '00:05:00', '00:02:00', '5:51', '22:21'),
	(100113, 1001, 212, '00:05:00', '00:02:30', '5:54', '22:23'),
	(100114, 1001, 1011, '00:05:00', '00:02:30', '5:56', '22:26'),
	(100115, 1001, 811, '00:05:00', '00:02:00', '5:58', '22:28'),
	(100116, 1001, 1012, '00:05:00', '00:02:00', '6:00', '22:30'),
	(100117, 1001, 111, '00:05:00', '00:03:00', '6:03', '22:33'),
	(100118, 1001, 1013, '00:05:00', '00:02:00', '6:05', '22:35'),
	(100119, 1001, 1014, '00:05:00', '00:02:00', '6:07', '22:37'),
	(100120, 1001, 305, '00:05:00', '00:03:00', '6:10', '22:40'),
	(100121, 1001, 1015, '00:05:00', '00:01:30', '6:12', '22:41'),
	(100122, 1001, 1016, '00:05:00', '00:01:30', '6:13', '22:43'),
	(100123, 1001, 1017, '00:05:00', '00:02:30', '6:16', '22:45'),
	(100124, 1001, 1018, '00:05:00', '00:02:00', '6:18', '22:47'),
	(100129, 1001, 1021, '00:10:00', '00:03:30', '6:21', '22:51'),
	(100130, 1001, 1022, '00:10:00', '00:02:00', '6:23', '22:53'),
	(100131, 1001, 1023, '00:10:00', '00:02:30', '6:26', '22:55'),

	-- 新江湾城 到 虹桥火车站
	(100201, 1002, 1001, '00:05:00', '00:00:00', '5:25', '22:05'),
	(100202, 1002, 1002, '00:05:00', '00:01:30', '5:26', '22:07'),
	(100203, 1002, 1003, '00:05:00', '00:02:00', '5:28', '22:09'),
	(100204, 1002, 1004, '00:05:00', '00:02:00', '5:30', '22:11'),
	(100205, 1002, 1005, '00:05:00', '00:02:00', '5:32', '22:13'),
	(100206, 1002, 1006, '00:05:00', '00:02:00', '5:34', '22:15'),
	(100207, 1002, 1007, '00:05:00', '00:01:30', '5:36', '22:16'),
	(100208, 1002, 817, '00:05:00', '00:02:30', '5:38', '22:19'),
	(100209, 1002, 1008, '00:05:00', '00:01:30', '5:40', '22:20'),
	(100210, 1002, 414, '00:05:00', '00:02:00', '5:42', '22:22'),
	(100211, 1002, 1009, '00:05:00', '00:02:30', '5:44', '22:25'),
	(100212, 1002, 1010, '00:05:00', '00:02:00', '5:46', '22:27'),
	(100213, 1002, 212, '00:05:00', '00:02:30', '5:49', '22:29'),
	(100214, 1002, 1011, '00:05:00', '00:02:00', '5:51', '22:31'),
	(100215, 1002, 811, '00:05:00', '00:02:00', '5:53', '22:33'),
	(100216, 1002, 1012, '00:05:00', '00:02:00', '5:55', '22:35'),
	(100217, 1002, 111, '00:05:00', '00:03:00', '5:58', '22:38'),
	(100218, 1002, 1013, '00:05:00', '00:02:30', '6:00', '22:41'),
	(100219, 1002, 1014, '00:05:00', '00:02:00', '6:02', '22:43'),
	(100220, 1002, 305, '00:05:00', '00:02:30', '6:05', '22:45'),
	(100221, 1002, 1015, '00:05:00', '00:02:00', '6:07', '22:47'),
	(100222, 1002, 1016, '00:05:00', '00:01:30', '6:08', '22:49'),
	(100223, 1002, 1017, '00:05:00', '00:02:30', '6:11', '22:51'),
	(100224, 1002, 1018, '00:05:00', '00:02:00', '6:13', '22:53'),
	(100225, 1002, 1019, '00:10:00', '00:02:00', '6:15', '22:55'),
	(100226, 1002, 1020, '00:10:00', '00:03:00', '6:18', '22:58'),
	(100227, 1002, 203, '00:10:00', '00:03:00', '6:21', '23:01'),
	(100228, 1002, 202, '00:10:00', '00:01:00', '6:22', '23:02'),

	-- 航中路 到 新江湾城
	(100301, 1003, 1023, '00:10:00', '00:00:00', '5:30', '22:01'),
	(100302, 1003, 1022, '00:10:00', '00:02:00', '5:32', '22:03'),
	(100303, 1003, 1021, '00:10:00', '00:02:00', '5:34', '22:05'),
	(100304, 1003, 1018, '00:05:00', '00:03:00', '5:37', '22:08'),
	(100305, 1003, 1017, '00:05:00', '00:03:00', '5:40', '22:11'),
	(100306, 1003, 1016, '00:05:00', '00:02:00', '5:42', '22:13'),
	(100307, 1003, 1015, '00:05:00', '00:01:30', '5:43', '22:15'),
	(100308, 1003, 305, '00:05:00', '00:02:30', '5:46', '22:17'),
	(100309, 1003, 1014, '00:05:00', '00:02:00', '5:48', '22:19'),
	(100310, 1003, 1013, '00:05:00', '00:02:00', '5:50', '22:21'),
	(100311, 1003, 111, '00:05:00', '00:03:00', '5:53', '22:24'),
	(100312, 1003, 1012, '00:05:00', '00:02:00', '5:55', '22:26'),
	(100313, 1003, 811, '00:05:00', '00:02:00', '5:57', '22:28'),
	(100314, 1003, 1011, '00:05:00', '00:03:00', '6:00', '22:31'),
	(100315, 1003, 212, '00:05:00', '00:02:30', '6:02', '22:34'),
	(100316, 1003, 1010, '00:05:00', '00:01:30', '6:04', '22:35'),
	(100317, 1003, 1009, '00:05:00', '00:02:00', '6:06', '22:37'),
	(100318, 1003, 414, '00:05:00', '00:02:00', '6:08', '22:39'),
	(100319, 1003, 1008, '00:05:00', '00:02:00', '6:10', '22:41'),
	(100320, 1003, 817, '00:05:00', '00:02:00', '6:12', '22:43'),
	(100321, 1003, 1007, '00:05:00', '00:02:00', '6:14', '22:45'),
	(100322, 1003, 1006, '00:05:00', '00:02:00', '6:16', '22:47'),
	(100323, 1003, 1005, '00:05:00', '00:02:00', '6:18', '22:49'),
	(100324, 1003, 1004, '00:05:00', '00:01:30', '6:19', '22:51'),
	(100325, 1003, 1003, '00:05:00', '00:02:30', '6:22', '22:53'),
	(100326, 1003, 1002, '00:05:00', '00:01:30', '6:23', '22:55'),
	(100327, 1003, 1001, '00:05:00', '00:02:00', '6:25', '22:57'),

	-- 虹桥火车站 到 新江湾城
	(100401, 1004, 202, '00:10:00', '00:00:00', '5:55', '22:05'),
	(100402, 1004, 203, '00:10:00', '00:01:00', '5:56', '22:06'),
	(100403, 1004, 1020, '00:10:00', '00:03:00', '5:59', '22:09'),
	(100404, 1004, 1019, '00:10:00', '00:03:00', '6:02', '22:12'),
	(100405, 1004, 1018, '00:05:00', '00:02:00', '6:04', '22:14'),
	(100406, 1004, 1017, '00:05:00', '00:02:30', '6:06', '22:17'),
	(100407, 1004, 1016, '00:05:00', '00:02:00', '6:08', '22:19'),
	(100408, 1004, 1015, '00:05:00', '00:02:00', '6:10', '22:21'),
	(100409, 1004, 305, '00:05:00', '00:02:00', '6:12', '22:23'),
	(100410, 1004, 1014, '00:05:00', '00:02:30', '6:15', '22:25'),
	(100411, 1004, 1013, '00:05:00', '00:02:00', '6:17', '22:27'),
	(100412, 1004, 111, '00:05:00', '00:02:30', '6:19', '22:30'),
	(100413, 1004, 1012, '00:05:00', '00:02:30', '6:22', '22:32'),
	(100414, 1004, 811, '00:05:00', '00:02:00', '6:24', '22:34'),
	(100415, 1004, 1011, '00:05:00', '00:03:00', '6:27', '22:37'),
	(100416, 1004, 212, '00:05:00', '00:02:00', '6:29', '22:39'),
	(100417, 1004, 1010, '00:05:00', '00:02:00', '6:31', '22:41'),
	(100418, 1004, 1009, '00:05:00', '00:02:00', '6:33', '22:43'),
	(100419, 1004, 414, '00:05:00', '00:02:00', '6:35', '22:45'),
	(100420, 1004, 1008, '00:05:00', '00:02:00', '6:37', '22:47'),
	(100421, 1004, 817, '00:05:00', '00:02:00', '6:39', '22:49'),
	(100422, 1004, 1007, '00:05:00', '00:02:00', '6:41', '22:51'),
	(100423, 1004, 1006, '00:05:00', '00:02:00', '6:43', '22:53'),
	(100424, 1004, 1005, '00:05:00', '00:02:00', '6:45', '22:55'),
	(100425, 1004, 1004, '00:05:00', '00:01:30', '6:46', '22:57'),
	(100426, 1004, 1003, '00:05:00', '00:02:00', '6:48', '22:59'),
	(100427, 1004, 1002, '00:05:00', '00:02:00', '6:50', '23:01'),
	(100428, 1004, 1001, '00:05:00', '00:02:00', '6:52', '23:03')

GO

INSERT INTO MetroTransfer VALUES
	-- 虹桥火车站 2，10号线
	(0201100201, 20121, 100228, '00:02:00', 1),
	(0201100401, 20121, 100401, '00:02:00', 1),
	(0202100201, 20202, 100228, '00:02:00', 1),
	(0202100401, 20202, 100401, '00:02:00', 1),
	(1002020101, 100228, 20121, '00:02:00', 1),
	(1002020201, 100228, 20202, '00:02:00', 1),
	(1004020101, 100401, 20121, '00:02:00', 1),
	(1004020201, 100401, 20202, '00:02:00', 1),

	-- 虹桥路 3，10号线
	(0301100101, 30106, 100120, '00:03:00', 1),
	(0301100201, 30106, 100220, '00:03:00', 1),
	(0302100101, 30224, 100120, '00:03:00', 1),
	(0302100201, 30224, 100220, '00:03:00', 1),
	(1001030101, 100120, 30106, '00:03:00', 1),
	(1001030201, 100120, 30224, '00:03:00', 1),
	(1002030101, 100220, 30106, '00:03:00', 1),
	(1002030201, 100220, 30224, '00:03:00', 1),
	(0301100301, 30106, 100308, '00:03:00', 1),
	(0301100401, 30106, 100409, '00:03:00', 1),
	(0302100301, 30224, 100308, '00:03:00', 1),
	(0302100401, 30224, 100409, '00:03:00', 1),
	(1003030101, 100308, 30106, '00:03:00', 1),
	(1003030201, 100308, 30224, '00:03:00', 1),
	(1004030101, 100409, 30106, '00:03:00', 1),
	(1004030201, 100409, 30224, '00:03:00', 1),
                                     
	-- 虹桥路 4，10号线              
	(0401100101, 40126, 100120, '00:03:00', 1),
	(0401100201, 40126, 100220, '00:03:00', 1),
	(0402100101, 40201, 100120, '00:03:00', 1),
	(0402100201, 40201, 100220, '00:03:00', 1),
	(1001040101, 100120, 40126, '00:03:00', 1),
	(1001040201, 100120, 40201, '00:03:00', 1),
	(1002040101, 100220, 40126, '00:03:00', 1),
	(1002040201, 100220, 40201, '00:03:00', 1),
	(0401100301, 40126, 100308, '00:03:00', 1),
	(0401100401, 40126, 100409, '00:03:00', 1),
	(0402100301, 40201, 100308, '00:03:00', 1),
	(0402100401, 40201, 100409, '00:03:00', 1),
	(1003040101, 100308, 40126, '00:03:00', 1),
	(1003040201, 100308, 40201, '00:03:00', 1),
	(1004040101, 100409, 40126, '00:03:00', 1),
	(1004040201, 100409, 40201, '00:03:00', 1),
	
	-- 陕西南路 1，10号线
	(0101100101, 10118, 100117, '00:03:00', 1),
	(0101100201, 10118, 100217, '00:03:00', 1),
	(0102100101, 10211, 100117, '00:03:00', 1),
	(0102100201, 10211, 100217, '00:03:00', 1),
	(1001010101, 100117, 10118, '00:03:00', 1),
	(1001010201, 100117, 10211, '00:03:00', 1),
	(1002010101, 100217, 10118, '00:03:00', 1),
	(1002010201, 100217, 10211, '00:03:00', 1),
	(0101100301, 10118, 100311, '00:03:00', 1),
	(0101100401, 10118, 100412, '00:03:00', 1),
	(0102100301, 10211, 100311, '00:03:00', 1),
	(0102100401, 10211, 100412, '00:03:00', 1),
	(1003010101, 100311, 10118, '00:03:00', 1),
	(1003010201, 100311, 10211, '00:03:00', 1),
	(1004010101, 100412, 10118, '00:03:00', 1),
	(1004010201, 100412, 10211, '00:03:00', 1),
	
	-- 老西门 8，10号线
	(0801100101, 80114, 100115, '00:01:00', 1),
	(0801100201, 80114, 100215, '00:01:00', 1),
	(0802100101, 80217, 100115, '00:01:00', 1),
	(0802100201, 80217, 100215, '00:01:00', 1),
	(1001080101, 100115, 80114, '00:01:00', 1),
	(1001080201, 100115, 80217, '00:01:00', 1),
	(1002080101, 100215, 80114, '00:01:00', 1),
	(1002080201, 100215, 80217, '00:01:00', 1),
	(0801100301, 80114, 100313, '00:01:00', 1),
	(0801100401, 80114, 100414, '00:01:00', 1),
	(0802100301, 80217, 100313, '00:01:00', 1),
	(0802100401, 80217, 100414, '00:01:00', 1),
	(1003080101, 100313, 80114, '00:01:00', 1),
	(1003080201, 100313, 80217, '00:01:00', 1),
	(1004080101, 100414, 80114, '00:01:00', 1),
	(1004080201, 100414, 80217, '00:01:00', 1),
	
	-- 南京东路 2，10号线
	(0201100102, 20110, 100113, '00:02:00', 1),
	(0201100202, 20110, 100213, '00:02:00', 1),
	(0202100102, 20213, 100113, '00:02:00', 1),
	(0202100202, 20213, 100213, '00:02:00', 1),
	(1001020102, 100113, 20110, '00:02:00', 1),
	(1001020202, 100113, 20213, '00:02:00', 1),
	(1002020102, 100213, 20110, '00:02:00', 1),
	(1002020202, 100213, 20213, '00:02:00', 1),
	(0201100302, 20110, 100315, '00:02:00', 1),
	(0201100402, 20110, 100416, '00:02:00', 1),
	(0202100302, 20213, 100315, '00:02:00', 1),
	(0202100402, 20213, 100416, '00:02:00', 1),
	(1003020102, 100315, 20110, '00:02:00', 1),
	(1003020202, 100315, 20213, '00:02:00', 1),
	(1004020102, 100416, 20110, '00:02:00', 1),
	(1004020202, 100416, 20213, '00:02:00', 1),

	-- 海伦路 4，10号线
	(0401100102, 40117, 100110, '00:01:00', 1),
	(0401100202, 40117, 100210, '00:01:00', 1),
	(0402100102, 40210, 100110, '00:01:00', 1),
	(0402100202, 40210, 100210, '00:01:00', 1),
	(1001040102, 100110, 40117, '00:01:00', 1),
	(1001040202, 100110, 40210, '00:01:00', 1),
	(1002040102, 100210, 40117, '00:01:00', 1),
	(1002040202, 100210, 40210, '00:01:00', 1),
	(0401100302, 40117, 100318, '00:01:00', 1),
	(0401100402, 40117, 100419, '00:01:00', 1),
	(0402100302, 40210, 100318, '00:01:00', 1),
	(0402100402, 40210, 100419, '00:01:00', 1),
	(1003040102, 100318, 40117, '00:01:00', 1),
	(1003040202, 100318, 40210, '00:01:00', 1),
	(1004040102, 100419, 40117, '00:01:00', 1),
	(1004040202, 100419, 40210, '00:01:00', 1),
	
	-- 四平路 8，10号线
	(0801100102, 80122, 100108, '00:01:00', 1),
	(0801100202, 80122, 100208, '00:01:00', 1),
	(0802100102, 80209, 100108, '00:01:00', 1),
	(0802100202, 80209, 100208, '00:01:00', 1),
	(1001080102, 100108, 80122, '00:01:00', 1),
	(1001080202, 100108, 80209, '00:01:00', 1),
	(1002080102, 100208, 80122, '00:01:00', 1),
	(1002080202, 100208, 80209, '00:01:00', 1),
	(0801100302, 80122, 100320, '00:01:00', 1),
	(0801100402, 80122, 100421, '00:01:00', 1),
	(0802100302, 80209, 100320, '00:01:00', 1),
	(0802100402, 80209, 100421, '00:01:00', 1),
	(1003080102, 100320, 80122, '00:01:00', 1),
	(1003080202, 100320, 80209, '00:01:00', 1),
	(1004080102, 100421, 80122, '00:01:00', 1),
	(1004080202, 100421, 80209, '00:01:00', 1),
	
	-- 龙溪路 航中路 到 虹桥火车站
	(1003100201, 100304, 100224, '00:00:00', 1),
	
	-- 龙溪路 虹桥火车站 到 航中路
	(1004100101, 100405, 100124, '00:00:00', 1),
	
	-- 虹桥2号航站楼 2，10号线
	(0201100203, 20120, 100227, '00:03:00', 0),
	(0201100403, 20120, 100402, '00:03:00', 0),
	(0202100203, 20203, 100227, '00:03:00', 0),
	(0202100403, 20203, 100402, '00:03:00', 0),
	(1002020103, 100227, 20120, '00:03:00', 0),
	(1002020203, 100227, 20203, '00:03:00', 0),
	(1004020103, 100402, 20120, '00:03:00', 0),
	(1004020203, 100402, 20203, '00:03:00', 0)
GO