using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NurApiDotNet;

using static NurApiDotNet.NurApi;

namespace UltrasonicSensorDemo
{
    class UltrasonicSensor
    {
        private NurApi nur;

        public UltrasonicSensor(string ip, int port = 4333)
        {
            nur = new NurApi();
            nur.ConnectSocket(ip, port);
        }

        public void EnableSensor()
        {
            nur.IOChangeEvent += new EventHandler<IOChangeEventArgs>(IOChangeEventHandler);
            nur.AccessorySensorChangedEvent += new EventHandler<AccessorySensorChangedEventArgs>(AccessorySensorChangedEventHandler);
            nur.AccessoryRangeDataEvent += new EventHandler<AccessoryRangeDataEventArgs>(AccessoryRangeDataEventHandler);
            nur.AccessoryEvent += new EventHandler<AccessoryEventArgs>(AccessoryEventHandler);
        }

        public void WaitForStateChanges()
        {
            string s;
            AccessorySensorConfig cfg = new AccessorySensorConfig();
            AccessorySensorFilter filter = new AccessorySensorFilter();

            Console.WriteLine("1: Enumerate sensors");
            Console.WriteLine("2: Get range sensor value");
            Console.WriteLine("3: Get sensor config");
            Console.WriteLine("4: Change sensor mode");
            Console.WriteLine("5: Get sensor filter");
            Console.WriteLine("6: Change sensor filter");

            for (; ; )
            {
                int key = Console.Read();
                switch (key)
                {
                    case '1':
                        List<AccessorySensorConfig> list = nur.AccSensorEnumerate();
                        Console.WriteLine($"Number of sensors: {list.Count}");
                        foreach (var c in list)
                        {
                            Console.WriteLine($"source: {c.source} type: {c.type} feature{c.feature} mode: {c.mode}");
                        }
                        break;
                    case '2':
                        AccSensorRangeData value = (AccSensorRangeData)nur.AccSensorGetValue(130);
                        Console.WriteLine($"source: {value.source} range: {value.range}");
                        break;
                    case '3':
                        cfg = nur.AccSensorGetConfig(130);
                        Console.WriteLine($"source: {cfg.source} type: {cfg.type} feature: {cfg.feature} mode: {cfg.mode}");
                        break;
                    case '4':
                        Console.WriteLine("Enter mode");
                        Console.Read();
                        s = Console.ReadLine();
                        int mode;
                        if (Int32.TryParse(s, out mode))
                        {
                            cfg.mode = (byte)mode;
                            cfg.source = 130;
                            nur.AccSensorSetConfig(cfg);
                        }
                        break;
                    case '5':
                        filter = nur.AccSensorGetFilter(130);
                        Console.WriteLine($"flags: {filter.flags} range lo/hi: {filter.rangeThreshold.lo}/{filter.timeThreshold.hi} time lo/hi: {filter.timeThreshold.lo}/{filter.timeThreshold.hi}");
                        break;
                    case '6':
                        Console.WriteLine("Enter flags");
                        Console.Read();
                        s = Console.ReadLine();
                        if (!UInt16.TryParse(s, out filter.flags))
                            break;
                        Console.WriteLine("Enter range lo");
                        s = Console.ReadLine();
                        if (!UInt16.TryParse(s, out filter.rangeThreshold.lo))
                            break;
                        Console.WriteLine("Enter range hi");
                        s = Console.ReadLine();
                        if (!UInt16.TryParse(s, out filter.rangeThreshold.hi))
                            break;
                        Console.WriteLine("Enter time lo");
                        s = Console.ReadLine();
                        if (!UInt16.TryParse(s, out filter.timeThreshold.lo))
                            break;
                        Console.WriteLine("Enter time hi");
                        s = Console.ReadLine();
                        if (!UInt16.TryParse(s, out filter.timeThreshold.hi))
                            break;
                        nur.AccSensorSetFilter(130, filter);
                        break;
                }
            }
        }

        private void IOChangeEventHandler(object sender, IOChangeEventArgs args)
        {
            Console.WriteLine($"sensor: {args.data.sensor}");
            Console.WriteLine($"source: {args.data.source}");
            Console.WriteLine($"dir:    {args.data.dir}");
        }

        private void AccessorySensorChangedEventHandler(object sender, AccessorySensorChangedEventArgs args)
        {
            Console.WriteLine($"Sensor source: {args.sensorChanged.source} removed: {args.sensorChanged.removed}");
        }

        private void AccessoryRangeDataEventHandler(object sender, AccessoryRangeDataEventArgs args)
        {
            Console.WriteLine($"Sensor source: {args.rangeData.source} range: {args.rangeData.range}");
        }

        private void AccessoryEventHandler(object sender, AccessoryEventArgs args)
        {
            Console.WriteLine($"data: {args.data[0]}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sensor = new UltrasonicSensor(args[0]);
            sensor.EnableSensor();
            sensor.WaitForStateChanges();
        }
    }
}
