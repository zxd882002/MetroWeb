USE MetroWeb
GO

INSERT INTO Station VALUES
	(601,'港城路'),
	(602,'外高桥保税区北'),
	(603,'航津路'),
	(604,'外高桥保税区南'),
	(605,'洲海路'),
	(606,'五洲大道'),
	(607,'东靖路'),
	(608,'巨峰路'),
	(609,'五莲路'),
	(610,'博兴路'),
	(611,'金桥路'),
	(612,'云山路'),
	(613,'德平路'),
	(614,'北洋泾路'),
	(615,'民生路'),
	(616,'源深体育中心'),
  --(215,'世纪大道'),
    (617,'浦电路'),
  --(408,'蓝村路'),
	(618,'上海儿童医学中心'),
	(619,'临沂新村'),
	(620,'高科西路'),
	(621,'东明路'),
	(622,'高青路'),
	(623,'华夏西路'),
	(624,'上南路'),
	(625,'灵岩南路'),
	(626,'东方体育中心')
GO

INSERT INTO Line VALUES
	(601,'6号线',601,626),
	(602,'6号线',626,601)
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 港城路 到 东方体育中心
	(60101, 601, 601, '00:10:00', '00:00:00', '5:30', '22:30'),
	(60102, 601, 602, '00:10:00', '00:02:00', '5:32', '22:32'),
	(60103, 601, 603, '00:10:00', '00:03:00', '5:35', '22:35'),
	(60104, 601, 604, '00:10:00', '00:03:00', '5:38', '22:38'),
	(60105, 601, 605, '00:10:00', '00:03:00', '5:41', '22:41'),
	(60106, 601, 606, '00:10:00', '00:02:00', '5:43', '22:43'),
	(60107, 601, 607, '00:10:00', '00:02:00', '5:45', '22:45'),
	(60108, 601, 608, '00:03:20', '00:02:00', '5:47', '22:47'),
	(60109, 601, 609, '00:03:20', '00:02:00', '5:49', '22:49'),
	(60110, 601, 610, '00:03:20', '00:03:00', '5:52', '22:52'),
	(60111, 601, 611, '00:03:20', '00:02:00', '5:54', '22:54'),
	(60112, 601, 612, '00:03:20', '00:02:00', '5:56', '22:56'),
	(60113, 601, 613, '00:03:20', '00:03:00', '5:59', '22:59'),
	(60114, 601, 614, '00:03:20', '00:02:00', '6:01', '23:01'),
	(60115, 601, 615, '00:03:20', '00:02:00', '6:03', '23:03'),
	(60116, 601, 616, '00:03:20', '00:03:00', '6:06', '23:06'),
	(60117, 601, 215, '00:03:20', '00:02:00', '6:08', '23:08'),
	(60118, 601, 617, '00:03:20', '00:03:00', '6:11', '23:11'),
	(60119, 601, 408, '00:03:20', '00:02:00', '6:13', '23:13'),
	(60120, 601, 618, '00:03:20', '00:03:00', '6:16', '23:16'),
	(60121, 601, 619, '00:03:20', '00:02:00', '6:18', '23:18'),
	(60122, 601, 620, '00:03:20', '00:03:00', '6:21', '23:21'),
	(60123, 601, 621, '00:03:20', '00:02:00', '6:23', '23:23'),
	(60124, 601, 622, '00:03:20', '00:03:00', '6:26', '23:26'),
	(60125, 601, 623, '00:10:00', '00:02:00', '6:28', '23:28'),
	(60126, 601, 624, '00:10:00', '00:02:00', '6:30', '23:30'),
	(60127, 601, 625, '00:10:00', '00:02:00', '6:32', '23:32'),
	(60128, 601, 626, '00:10:00', '00:02:00', '6:34', '23:34'),
	-- 东方体育中心 到 港城路
	(60201, 602, 626, '00:10:00', '00:00:00', '5:30', '22:30'),
	(60202, 602, 625, '00:10:00', '00:02:00', '5:32', '22:32'),
	(60203, 602, 624, '00:10:00', '00:02:00', '5:34', '22:34'),
	(60204, 602, 623, '00:10:00', '00:02:00', '5:36', '22:36'),
	(60205, 602, 622, '00:03:20', '00:03:00', '5:39', '22:39'),
	(60206, 602, 621, '00:03:20', '00:02:00', '5:41', '22:41'),
	(60207, 602, 620, '00:03:20', '00:03:00', '5:44', '22:44'),
	(60208, 602, 619, '00:03:20', '00:02:00', '5:46', '22:46'),
	(60209, 602, 618, '00:03:20', '00:03:00', '5:49', '22:49'),
	(60210, 602, 408, '00:03:20', '00:03:00', '5:52', '22:52'),
	(60211, 602, 617, '00:03:20', '00:02:00', '5:54', '22:54'),
	(60212, 602, 215, '00:03:20', '00:03:00', '5:57', '22:57'),
	(60213, 602, 616, '00:03:20', '00:02:00', '5:59', '22:59'),
	(60214, 602, 615, '00:03:20', '00:02:00', '6:01', '23:01'),
	(60215, 602, 614, '00:03:20', '00:02:00', '6:03', '23:03'),
	(60216, 602, 613, '00:03:20', '00:03:00', '6:06', '23:06'),
	(60217, 602, 612, '00:03:20', '00:02:00', '6:08', '23:08'),
	(60218, 602, 611, '00:03:20', '00:03:00', '6:11', '23:11'),
	(60219, 602, 610, '00:03:20', '00:02:00', '6:13', '23:13'),
	(60220, 602, 609, '00:03:20', '00:02:00', '6:15', '23:15'),
	(60221, 602, 608, '00:03:20', '00:02:00', '6:17', '23:17'),
	(60222, 602, 607, '00:10:00', '00:03:00', '6:20', '23:20'),
	(60223, 602, 606, '00:10:00', '00:02:00', '6:22', '23:22'),
	(60224, 602, 605, '00:10:00', '00:02:00', '6:24', '23:24'),
	(60225, 602, 604, '00:10:00', '00:03:00', '6:27', '23:27'),
	(60226, 602, 603, '00:10:00', '00:03:00', '6:30', '23:30'),
	(60227, 602, 602, '00:10:00', '00:02:00', '6:32', '23:32'),
	(60228, 602, 601, '00:10:00', '00:03:00', '6:35', '23:35')	
GO

INSERT INTO InterChange VALUES
	-- 世纪大道 2，6号线
	(0201060101, 20107, 60117, '00:02:00'),
	(0201060201, 20107, 60212, '00:02:00'),
	(0202060101, 20216, 60117, '00:02:00'),
	(0202060201, 20216, 60212, '00:02:00'),
	(0601020101, 60117, 20107, '00:02:00'),
	(0601020201, 60117, 20216, '00:02:00'),
	(0602020101, 60212, 20107, '00:02:00'),
	(0602020201, 60212, 20216, '00:02:00'),
	-- 世纪大道 4，6号线
	(0401060101, 40112, 60117, '00:00:00'),
	(0401060201, 40112, 60212, '00:00:00'),
	(0402060101, 40215, 60117, '00:00:00'),
	(0402060201, 40215, 60212, '00:00:00'),
	(0601040101, 60117, 40112, '00:00:00'),
	(0601040201, 60117, 40215, '00:00:00'),
	(0602040101, 60212, 40112, '00:00:00'),
	(0602040201, 60212, 40215, '00:00:00'),
	-- 蓝村路 4，6号线
	(0401060102, 40110, 60119, '00:00:00'),
	(0401060202, 40110, 60210, '00:00:00'),
	(0402060102, 40217, 60119, '00:00:00'),
	(0402060202, 40217, 60210, '00:00:00'),
	(0601040102, 60119, 40110, '00:00:00'),
	(0601040202, 60119, 40217, '00:00:00'),
	(0602040102, 60210, 40110, '00:00:00'),
	(0602040202, 60210, 40217, '00:00:00')
GO