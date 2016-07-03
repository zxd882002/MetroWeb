USE MetroWeb
GO

INSERT INTO Station VALUES
  (801, '沈杜公路'),
  (802, '联航路'),
  (803, '江月路'),
  (804, '浦江镇'),
  (805, '芦恒路'),
  (806, '凌兆新村'),
--(626, '东方体育中心'),
  (807, '杨思'),
  (808, '成山路'),
--(706, '耀华路'),
  (809, '中华艺术宫'),
--(405, '西藏南路'),
  (810, '陆家浜路'),
  (811, '老西门'),
  (812, '大世界'),
--(113, '人民广场'),
  (813, '曲阜路'),
  (814, '中兴路'),
  (815, '西藏北路'),
--(313, '虹口足球场'),
  (816, '曲阳路'),
  (817, '四平路'),
  (818, '鞍山新村'),
  (819, '江浦路'),
  (820, '黄兴路'),
  (821, '延吉中路'),
  (822, '黄兴公园'),
  (823, '翔殷路'),
  (824, '嫩江路'),
  (825, '市光路')
GO

INSERT INTO Line VALUES
	(801,'8号线',801,825),
	(802,'8号线',825,801)
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 沈杜公路 到 市光路
	(80101, 801, 801, '00:03:40', '00:00:00', '5:30', '22:30'),
	(80102, 801, 802, '00:03:40', '00:02:00', '5:32', '22:32'),
	(80103, 801, 803, '00:03:40', '00:02:00', '5:34', '22:34'),
	(80104, 801, 804, '00:03:40', '00:02:00', '5:36', '22:36'),
	(80105, 801, 805, '00:03:40', '00:04:00', '5:40', '22:40'),
	(80106, 801, 806, '00:03:40', '00:03:00', '5:43', '22:43'),
	(80107, 801, 626, '00:03:40', '00:04:00', '5:47', '22:47'),
	(80108, 801, 807, '00:03:40', '00:02:00', '5:49', '22:49'),
	(80109, 801, 808, '00:03:40', '00:02:00', '5:51', '22:51'),
	(80110, 801, 706, '00:03:40', '00:02:00', '5:53', '22:53'),
	(80111, 801, 809, '00:03:40', '00:02:00', '5:55', '22:55'),
	(80112, 801, 405, '00:03:40', '00:03:00', '5:58', '22:58'),
	(80113, 801, 810, '00:03:40', '00:02:00', '6:00', '23:00'),
	(80114, 801, 811, '00:03:40', '00:02:00', '6:02', '23:02'),
	(80115, 801, 812, '00:03:40', '00:02:00', '6:04', '23:04'),
	(80116, 801, 113, '00:03:40', '00:02:00', '6:06', '23:06'),
	(80117, 801, 813, '00:03:40', '00:02:00', '6:08', '23:08'),
	(80118, 801, 814, '00:03:40', '00:02:00', '6:10', '23:10'),
	(80119, 801, 815, '00:03:40', '00:03:00', '6:13', '23:13'),
	(80120, 801, 313, '00:03:40', '00:02:00', '6:15', '23:15'),
	(80121, 801, 816, '00:03:40', '00:03:00', '6:18', '23:18'),
	(80122, 801, 817, '00:03:40', '00:02:00', '6:20', '23:20'),
	(80123, 801, 818, '00:03:40', '00:02:00', '6:22', '23:22'),
	(80124, 801, 819, '00:03:40', '00:02:00', '6:24', '23:24'),
	(80125, 801, 820, '00:03:40', '00:02:00', '6:26', '23:26'),
	(80126, 801, 821, '00:03:40', '00:02:00', '6:28', '23:28'),
	(80127, 801, 822, '00:03:40', '00:02:00', '6:30', '23:30'),
	(80128, 801, 823, '00:03:40', '00:02:00', '6:32', '23:32'),
	(80129, 801, 824, '00:03:40', '00:02:00', '6:34', '23:34'),
	(80130, 801, 825, '00:03:40', '00:02:00', '6:36', '23:36'),

	-- 市光路 到 沈杜公路
	(80201, 802, 825, '00:03:40', '00:00:00', '5:30', '22:30'),
	(80202, 802, 824, '00:03:40', '00:01:00', '5:31', '22:31'),
	(80203, 802, 823, '00:03:40', '00:02:00', '5:33', '22:33'),
	(80204, 802, 822, '00:03:40', '00:02:00', '5:35', '22:35'),
	(80205, 802, 821, '00:03:40', '00:02:00', '5:37', '22:37'),
	(80206, 802, 820, '00:03:40', '00:03:00', '5:40', '22:40'),
	(80207, 802, 819, '00:03:40', '00:02:00', '5:42', '22:42'),
	(80208, 802, 818, '00:03:40', '00:02:00', '5:44', '22:44'),
	(80209, 802, 817, '00:03:40', '00:02:00', '5:46', '22:46'),
	(80210, 802, 816, '00:03:40', '00:02:00', '5:48', '22:48'),
	(80211, 802, 313, '00:03:40', '00:02:00', '5:50', '22:50'),
	(80212, 802, 815, '00:03:40', '00:03:00', '5:53', '22:53'),
	(80213, 802, 814, '00:03:40', '00:02:00', '5:55', '22:55'),
	(80214, 802, 813, '00:03:40', '00:02:00', '5:57', '22:57'),
	(80215, 802, 113, '00:03:40', '00:03:00', '6:00', '23:00'),
	(80216, 802, 812, '00:03:40', '00:01:00', '6:01', '23:01'),
	(80217, 802, 811, '00:03:40', '00:02:00', '6:03', '23:03'),
	(80218, 802, 810, '00:03:40', '00:02:00', '6:05', '23:05'),
	(80219, 802, 405, '00:03:40', '00:03:00', '6:08', '23:08'),
	(80220, 802, 809, '00:03:40', '00:02:00', '6:10', '23:10'),
	(80221, 802, 706, '00:03:40', '00:02:00', '6:12', '23:12'),
	(80222, 802, 808, '00:03:40', '00:02:00', '6:14', '23:14'),
	(80223, 802, 807, '00:03:40', '00:02:00', '6:16', '23:16'),
	(80224, 802, 626, '00:03:40', '00:03:00', '6:19', '23:19'),
	(80225, 802, 806, '00:03:40', '00:03:00', '6:22', '23:22'),
	(80226, 802, 805, '00:03:40', '00:03:00', '6:25', '23:25'),
	(80227, 802, 804, '00:03:40', '00:04:00', '6:29', '23:29'),
	(80228, 802, 803, '00:03:40', '00:02:00', '6:31', '23:31'),
	(80229, 802, 802, '00:03:40', '00:02:00', '6:33', '23:33'),
	(80230, 802, 801, '00:03:40', '00:02:00', '6:35', '23:35')
GO

INSERT INTO MetroTransfer VALUES
	-- 东方体育中心 6，8号线
	(0601080101, 60128, 80107, '00:01:00', 1),
	(0601080201, 60128, 80224, '00:01:00', 1),
	(0801060201, 80107, 60201, '00:01:00', 1),
	(0802060201, 80224, 60201, '00:01:00', 1),

	-- 耀华路 7，8号线
	(0701080101, 70108, 80110, '00:01:00', 1),
	(0701080201, 70108, 80221, '00:01:00', 1),
	(0702080101, 70226, 80110, '00:01:00', 1),
	(0702080201, 70226, 80221, '00:01:00', 1),
	(0801070101, 80110, 70108, '00:01:00', 1),
	(0801070201, 80110, 70226, '00:01:00', 1),
	(0802070101, 80221, 70108, '00:01:00', 1),
	(0802070201, 80221, 70226, '00:01:00', 1),

	-- 西藏南路 4，8号线
	(0401080101, 40107, 80112, '00:01:00', 1),
	(0401080201, 40107, 80219, '00:01:00', 1),
	(0402080101, 40220, 80112, '00:01:00', 1),
	(0402080201, 40220, 80219, '00:01:00', 1),
	(0801040101, 80112, 40107, '00:01:00', 1),
	(0801040201, 80112, 40220, '00:01:00', 1),
	(0802040101, 80219, 40107, '00:01:00', 1),
	(0802040201, 80219, 40220, '00:01:00', 1),

	-- 人民广场 1，8号线
	(0101080101, 10116, 80116, '00:02:00', 1),
	(0101080201, 10116, 80215, '00:02:00', 1),
	(0102080101, 10213, 80116, '00:02:00', 1),
	(0102080201, 10213, 80215, '00:02:00', 1),
	(0801010101, 80116, 10116, '00:02:00', 1),
	(0801010201, 80116, 10213, '00:02:00', 1),
	(0802010101, 80215, 10116, '00:02:00', 1),
	(0802010201, 80215, 10213, '00:02:00', 1),
	
	-- 人民广场 2，8号线
	(0201080101, 20111, 80116, '00:03:00', 1),
	(0201080201, 20111, 80215, '00:03:00', 1),
	(0202080101, 20212, 80116, '00:03:00', 1),
	(0202080201, 20212, 80215, '00:03:00', 1),
	(0801020101, 80116, 20111, '00:03:00', 1),
	(0801020201, 80116, 20212, '00:03:00', 1),
	(0802020101, 80215, 20111, '00:03:00', 1),
	(0802020201, 80215, 20212, '00:03:00', 1),

	-- 虹口足球场 3，8号线
	(0301080101, 30116, 80120, '00:03:00', 1),
	(0301080201, 30116, 80211, '00:03:00', 1),
	(0302080101, 30214, 80120, '00:03:00', 1),
	(0302080201, 30214, 80211, '00:03:00', 1),
	(0801030101, 80120, 30116, '00:03:00', 1),
	(0801030201, 80120, 30214, '00:03:00', 1),
	(0802030101, 80211, 30116, '00:03:00', 1),
	(0802030201, 80211, 30214, '00:03:00', 1)
GO