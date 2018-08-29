// <copyright file="AcUdpClient.cs" company="Racing Sim Tools">
// Copyright (c) Racing Sim Tools. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace AcUdpNet
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.MemoryMappedFiles;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Reactive;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Reactive.Threading;
    using System.Reactive.Threading.Tasks;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Client class used to connect and read packets from the AC Server.
    /// </summary>
    public sealed class AcUdpClient : IDisposable
    {
        private readonly UdpClient udpClient;
        private IPEndPoint serverEndPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcUdpClient"/> class.
        /// </summary>
        /// <param name="serverIP">The IP Adress of the AC Server</param>
        public AcUdpClient(IPAddress serverIP)
        {
            this.serverEndPoint = new IPEndPoint(serverIP, 9996);
            this.udpClient = new UdpClient();
        }

        /// <summary>
        /// Gets or sets stream containing the packets read from the AC server.
        /// </summary>
        public IObservable<CarInfoPacket> CarInfoStream { get; set; }

        /// <summary>
        /// Performs the initial handshake to open connection with the AC server.
        /// </summary>
        /// <returns>The response from the server</returns>
        public HandshakerResponse? PerformInitialHandshake()
        {
            Handshaker hs = new Handshaker
            {
                Identifier = 1,
                Version = 1,
                OperationId = 0 // Open connection operation;
            };
            byte[] packet = this.GetBytes(hs);
            this.udpClient.Send(packet, packet.Length, this.serverEndPoint);

            try
            {
                return this.GetHandshakerResponse(this.udpClient.Receive(ref this.serverEndPoint));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        /// <summary>
        /// Instructs the client to perform an update handshake with the AC server.
        /// </summary>
        public void PerformUpdateHandshake()
        {
            Handshaker hs = new Handshaker
            {
                Identifier = 1,
                Version = 1,
                OperationId = 1 // Update connection operation;
            };
            byte[] packet = this.GetBytes(hs);
            this.udpClient.Send(packet, packet.Length, this.serverEndPoint);
        }

        /// <summary>
        /// Start reading the telemetry into the <see cref="CarInfoStream"/>.
        /// </summary>
        public void StartTelemetry()
        {
            this.PerformUpdateHandshake();
            this.CarInfoStream = Observable.FromAsync(this.udpClient.ReceiveAsync)
                .Repeat()
                .Publish()
                .RefCount()
                .Select(p => this.MarshalCarInfoPacket(p))
                .DistinctUntilChanged(new CarInfoPacketEquality());
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.udpClient.Close();
            this.udpClient.Dispose();
        }

        private CarInfoPacket MarshalCarInfoPacket(UdpReceiveResult result)
        {
            byte[] arr = result.Buffer;

            CarInfoPacket str = default(CarInfoPacket);

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (CarInfoPacket)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        private byte[] GetBytes(Handshaker hs)
        {
            int size = Marshal.SizeOf(hs);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(hs, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        private HandshakerResponse GetHandshakerResponse(byte[] arr)
        {
            HandshakerResponse str = default(HandshakerResponse);

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (HandshakerResponse)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }
    }
}
