using System;

namespace MetroWebWCFService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    public class Service1 : IMetroWebService
    {
        public StationInfo GetStationInformation(int value)
        {
            throw new NotImplementedException();
        }

        public RouteAndPrice GetTwoStationsRouteAndPrice(int value)
        {
            throw new NotImplementedException();
        }
    }
}
