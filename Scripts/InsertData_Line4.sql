USE MetroWeb
GO

INSERT INTO Station VALUES
    --(304,'宜山路'),
	--(107,'上海体育馆'),
	(401,'上海体育场'),
	(402,'东安路'),
	(403,'大木桥路'),
	(404,'鲁班路'),
	(405,'西藏南路'),
	(406,'南浦大桥'),
	(407,'塘桥'),
	(408,'蓝村路'),
	(409,'浦电路'),
	--(215,'世纪大道'),
	(410,'浦东大道'),
	(411,'杨树浦路'),
	(412,'大连路'),
	(413,'临平路'),
	(414,'海伦路')
	--(311,'宝山路')
	--(116,'上海火车站'),
	--(310,'中潭路'),
	--(309,'镇坪路'),
	--(308,'曹杨路'),
	--(307,'金沙江路'),
	--(208,'中山公园'),
	--(306,'延安西路'),	
	--(305,'虹桥路')
GO

INSERT INTO Line VALUES
	(401,'4号线-外圈',304,305),
	(402,'4号线-内圈',305,304)
GO

-- id, line, station, duration, last_station_cost, start, end
INSERT INTO StationLine VALUES
	-- 宜山路 到 虹桥路 外圈
	(40101, 401, 304, '0:06:30', '00:02:00', '5:30', '22:30'),
	(40102, 401, 107, '0:06:30', '00:02:00', '5:32', '22:32'),
	(40103, 401, 401, '0:06:30', '00:02:00', '5:34', '22:34'),
	(40104, 401, 402, '0:06:30', '00:02:00', '5:36', '22:36'),
	(40105, 401, 403, '0:06:30', '00:01:00', '5:37', '22:37'),
	(40106, 401, 404, '0:06:30', '00:02:00', '5:39', '22:39'),
	(40107, 401, 405, '0:06:30', '00:03:00', '5:42', '22:42'),
	(40108, 401, 406, '0:06:30', '00:02:00', '5:44', '22:44'),
	(40109, 401, 407, '0:06:30', '00:03:00', '5:47', '22:47'),
	(40110, 401, 408, '0:06:30', '00:02:00', '5:49', '22:49'),
	(40111, 401, 409, '0:06:30', '00:02:00', '5:51', '22:51'),
	(40112, 401, 215, '0:06:30', '00:02:00', '5:53', '22:53'),
	(40113, 401, 410, '0:06:30', '00:03:00', '5:56', '22:56'),
	(40114, 401, 411, '0:06:30', '00:02:00', '5:58', '22:58'),
	(40115, 401, 412, '0:06:30', '00:02:00', '6:00', '23:00'),
	(40116, 401, 413, '0:06:30', '00:02:00', '6:02', '23:02'),
	(40117, 401, 414, '0:06:30', '00:02:00', '6:04', '23:04'),
	(40118, 401, 311, '0:06:30', '00:03:00', '6:07', '23:07'),
	(40119, 401, 116, '0:06:30', '00:03:00', '6:10', '23:10'),
	(40120, 401, 310, '0:06:30', '00:03:00', '6:13', '23:13'),
	(40121, 401, 309, '0:06:30', '00:02:00', '6:15', '23:15'),
	(40122, 401, 308, '0:06:30', '00:03:00', '6:18', '23:18'),
	(40123, 401, 307, '0:06:30', '00:01:00', '6:19', '23:19'),
	(40124, 401, 208, '0:06:30', '00:03:00', '6:22', '23:22'),
	(40125, 401, 306, '0:06:30', '00:02:00', '6:24', '23:24'),
	(40126, 401, 305, '0:06:30', '00:02:00', '6:26', '23:26'),
	-- 虹桥路 到 宜山路 内圈
	(40201, 402, 305, '0:06:30', '00:02:00', '5:32', '22:32'),
	(40202, 402, 306, '0:06:30', '00:03:00', '5:35', '22:35'),
	(40203, 402, 208, '0:06:30', '00:02:00', '5:37', '22:37'),
	(40204, 402, 307, '0:06:30', '00:02:00', '5:39', '22:39'),
	(40205, 402, 308, '0:06:30', '00:02:00', '5:41', '22:41'),
	(40206, 402, 309, '0:06:30', '00:03:00', '5:44', '22:44'),
	(40207, 402, 310, '0:06:30', '00:02:00', '5:46', '22:46'),
	(40208, 402, 116, '0:06:30', '00:03:00', '5:49', '22:49'),
	(40209, 402, 311, '0:06:30', '00:03:00', '5:52', '22:52'),
	(40210, 402, 414, '0:06:30', '00:03:00', '5:55', '22:55'),
	(40211, 402, 413, '0:06:30', '00:02:00', '5:57', '22:57'),
	(40212, 402, 412, '0:06:30', '00:02:00', '5:59', '22:59'),
	(40213, 402, 411, '0:06:30', '00:02:00', '6:01', '23:01'),
	(40214, 402, 410, '0:06:30', '00:02:00', '6:03', '23:03'),
	(40215, 402, 215, '0:06:30', '00:02:00', '6:05', '23:05'),
	(40216, 402, 409, '0:06:30', '00:02:00', '6:07', '23:07'),
	(40217, 402, 408, '0:06:30', '00:03:00', '6:10', '23:10'),
	(40218, 402, 407, '0:06:30', '00:02:00', '6:12', '23:12'),
	(40219, 402, 406, '0:06:30', '00:03:00', '6:15', '23:15'),
	(40220, 402, 405, '0:06:30', '00:02:00', '6:17', '23:17'),
	(40221, 402, 404, '0:06:30', '00:02:00', '6:19', '23:19'),
	(40222, 402, 403, '0:06:30', '00:02:00', '6:21', '23:21'),
	(40223, 402, 402, '0:06:30', '00:02:00', '6:23', '23:23'),
	(40224, 402, 401, '0:06:30', '00:02:00', '6:25', '23:25'),
	(40225, 402, 107, '0:06:30', '00:02:00', '6:27', '23:27'),
	(40226, 402, 304, '0:06:30', '00:03:00', '6:30', '23:30')
GO

INSERT INTO MetroTransfer VALUES
	-- 宜山路 3，4号线 
	(0301040101, 30105, 40101, '00:00:00', 1),
	(0301040201, 30105, 40226, '00:00:00', 1),
	(0302040101, 30225, 40101, '00:00:00', 1),
	(0302040201, 30225, 40226, '00:00:00', 1),
	(0401030101, 40101, 30105, '00:00:00', 1),
	(0401030201, 40101, 30225, '00:00:00', 1),
	(0402030101, 40226, 30105, '00:00:00', 1),
	(0402030201, 40226, 30225, '00:00:00', 1),
	-- 上海体育馆 1，4号线           
	(0101040101, 10121, 40102, '00:03:00', 1),
	(0101040201, 10121, 40225, '00:03:00', 1),
	(0102040101, 10207, 40102, '00:03:00', 1),
	(0102040201, 10207, 40225, '00:03:00', 1),
	(0401010101, 40102, 10121, '00:03:00', 1),
	(0401010201, 40102, 10207, '00:03:00', 1),
	(0402010101, 40225, 10121, '00:03:00', 1),
	(0402010201, 40225, 10207, '00:03:00', 1),
	-- 宝山路 3，4号线                
	(0301040102, 30114, 40118, '00:00:00', 1),
	(0301040202, 30114, 40118, '00:00:00', 1),
	(0302040102, 30216, 40209, '00:00:00', 1),
	(0302040202, 30216, 40209, '00:00:00', 1),
	(0401030102, 40118, 30114, '00:00:00', 1),
	(0401030202, 40118, 30216, '00:00:00', 1),
	(0402030102, 40209, 30114, '00:00:00', 1),
	(0402030202, 40209, 30216, '00:00:00', 1),
	-- 上海火车站 3，4号线             
	(0301040103, 30113, 40119, '00:00:00', 1),
	(0301040203, 30113, 40208, '00:00:00', 1),
	(0302040103, 30217, 40119, '00:00:00', 1),
	(0302040203, 30217, 40208, '00:00:00', 1),
	(0401030103, 40119, 30113, '00:00:00', 1),
	(0401030203, 40119, 30217, '00:00:00', 1),
	(0402030103, 40208, 30113, '00:00:00', 1),
	(0402030203, 40208, 30217, '00:00:00', 1),
	-- 中潭路 3，4号线                  
	(0301040104, 30112, 40120, '00:00:00', 1),
	(0301040204, 30112, 40207, '00:00:00', 1),
	(0302040104, 30218, 40120, '00:00:00', 1),
	(0302040204, 30218, 40207, '00:00:00', 1),
	(0401030104, 40120, 30112, '00:00:00', 1),
	(0401030204, 40120, 30218, '00:00:00', 1),
	(0402030104, 40207, 30112, '00:00:00', 1),
	(0402030204, 40207, 30218, '00:00:00', 1),
	-- 镇坪路 3，4号线                  
	(0301040105, 30111, 40121, '00:00:00', 1),
	(0301040205, 30111, 40206, '00:00:00', 1),
	(0302040105, 30219, 40121, '00:00:00', 1),
	(0302040205, 30219, 40206, '00:00:00', 1),
	(0401030105, 40121, 30111, '00:00:00', 1),
	(0401030205, 40121, 30219, '00:00:00', 1),
	(0402030105, 40206, 30111, '00:00:00', 1),
	(0402030205, 40206, 30219, '00:00:00', 1),
	-- 曹杨路 3，4号线                   
	(0301040106, 30110, 40122, '00:00:00', 1),
	(0301040206, 30110, 40205, '00:00:00', 1),
	(0302040106, 30220, 40122, '00:00:00', 1),
	(0302040206, 30220, 40205, '00:00:00', 1),
	(0401030106, 40122, 30110, '00:00:00', 1),
	(0401030206, 40122, 30220, '00:00:00', 1),
	(0402030106, 40205, 30110, '00:00:00', 1),
	(0402030206, 40205, 30220, '00:00:00', 1),
	-- 金沙江路 3，4号线                
	(0301040107, 30109, 40123, '00:00:00', 1),
	(0301040207, 30109, 40204, '00:00:00', 1),
	(0302040107, 30221, 40123, '00:00:00', 1),
	(0302040207, 30221, 40204, '00:00:00', 1),
	(0401030107, 40123, 30109, '00:00:00', 1),
	(0401030207, 40123, 30221, '00:00:00', 1),
	(0402030107, 40204, 30109, '00:00:00', 1),
	(0402030207, 40204, 30221, '00:00:00', 1),
	-- 中山公园 2，4号线                
	(0201040101, 20115, 40124, '00:05:00', 1),
	(0201040201, 20115, 40203, '00:05:00', 1),
	(0202040101, 20208, 40124, '00:05:00', 1),
	(0202040201, 20208, 40203, '00:05:00', 1),
	(0401020101, 40124, 20115, '00:05:00', 1),
	(0401020201, 40124, 20208, '00:05:00', 1),
	(0402020101, 40203, 20115, '00:05:00', 1),
	(0402020201, 40203, 20208, '00:05:00', 1),
	-- 中山公园 3，4号线                
	(0301040108, 30108, 40124, '00:00:00', 1),
	(0301040208, 30108, 40203, '00:00:00', 1),
	(0302040108, 30222, 40124, '00:00:00', 1),
	(0302040208, 30222, 40203, '00:00:00', 1),
	(0401030108, 40124, 30108, '00:00:00', 1),
	(0401030208, 40124, 30222, '00:00:00', 1),
	(0402030108, 40203, 30108, '00:00:00', 1),
	(0402030208, 40203, 30222, '00:00:00', 1),
	-- 延安西路 3，4号线                
	(0301040109, 30107, 40125, '00:00:00', 1),
	(0301040209, 30107, 40202, '00:00:00', 1),
	(0302040109, 30223, 40125, '00:00:00', 1),
	(0302040209, 30223, 40202, '00:00:00', 1),
	(0401030109, 40125, 30107, '00:00:00', 1),
	(0401030209, 40125, 30223, '00:00:00', 1),
	(0402030109, 40202, 30107, '00:00:00', 1),
	(0402030209, 40202, 30223, '00:00:00', 1),
	-- 虹桥路 3，4号线                  
	(0301040110, 30106, 40126, '00:00:00', 1),
	(0301040210, 30106, 40201, '00:00:00', 1),
	(0302040110, 30224, 40126, '00:00:00', 1),
	(0302040210, 30224, 40201, '00:00:00', 1),
	(0401030110, 40126, 30106, '00:00:00', 1),
	(0401030210, 40126, 30224, '00:00:00', 1),
	(0402030110, 40201, 30106, '00:00:00', 1),
	(0402030210, 40201, 30224, '00:00:00', 1),
	-- 世纪大道 2，4号线               
	(0201040102, 20107, 40112, '00:02:00', 1),
	(0201040202, 20107, 40215, '00:02:00', 1),
	(0202040102, 20216, 40112, '00:02:00', 1),
	(0202040202, 20216, 40215, '00:02:00', 1),
	(0401020102, 40112, 20107, '00:02:00', 1),
	(0401020202, 40112, 20216, '00:02:00', 1),
	(0402020102, 40215, 20107, '00:02:00', 1),
	(0402020202, 40215, 20216, '00:02:00', 1), 
	-- 上海火车站 1，4号线	             
	(0101040102, 10112, 40119, '00:07:00', 0),
	(0101040202, 10112, 40208, '00:07:00', 0),
	(0102040102, 10216, 40119, '00:07:00', 0),
	(0102040202, 10216, 40208, '00:07:00', 0),
	(0401010102, 40119, 10112, '00:07:00', 0),
	(0401010202, 40119, 10216, '00:07:00', 0),
	(0402010102, 40208, 10112, '00:07:00', 0),
	(0402010202, 40208, 10216, '00:07:00', 0)
GO