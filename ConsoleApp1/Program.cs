// <copyright file="Program.cs" company="Racing Sim Tools">
// Copyright (c) Racing Sim Tools. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AcUdpNet;

    public static class Program
    {
        public static void Main()
        {
            AcUdpClient client = new AcUdpClient(IPAddress.Parse("127.0.0.1"));
            Console.WriteLine(client.PerformInitialHandshake().HasValue);
            client.StartTelemetry();
            IObserver<CarInfoPacket> observer = Observer
                .Create<CarInfoPacket>(output => Console.WriteLine(output.EngineRPM));
            var disp = client.CarInfoStream.
                Subscribe(observer);
            while (true)
            {
            }
        }

        public static CarInfoPacket Save(CarInfoPacket pack)
        {
            return pack;
        }

        public static async void GetInfo(AcUdpClient client)
        {
            while (true)
            {
                var i = await client.CarInfoStream;
                Console.WriteLine(i.EngineRPM);
            }
        }
    }
}
