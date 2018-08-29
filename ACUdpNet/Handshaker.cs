// <copyright file="Handshaker.cs" company="Racing Sim Tools">
// Copyright (c) Racing Sim Tools. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

#pragma warning disable CA1051 // Do not declare visible instance fields
namespace AcUdpNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Structure of the packet used to perform handshake with AC Server.
    /// </summary>
    public struct Handshaker : IEquatable<Handshaker>
    {
        /// <summary>
        /// Not Currently Used: Identifies the platform type of the client.
        /// </summary>
        public int Identifier;

        /// <summary>
        /// Not Currently Used: Identify the version of the telemetry that the client
        /// expects to speak to.
        /// </summary>
        public int Version;

        /// <summary>
        /// The type of operation requested by the client.
        /// [ Handshake = 0 ]
        /// [ Subscribe update = 1]
        /// [ Subscribe spot = 2 ]
        /// [ Dismiss = 3 ]
        /// </summary>
        public int OperationId;

        /// <summary>
        /// Returns true if the left <see cref="CarInfoPacket"/> does equal the right
        /// <see cref="CarInfoPacket"/>.
        /// </summary>
        /// <param name="left">A <see cref="CarInfoPacket"/> to be compared to right</param>
        /// <param name="right">A <see cref="CarInfoPacket"/> to be compared to left</param>
        /// <returns>true or false</returns>
        public static bool operator ==(Handshaker left, Handshaker right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Returns true if the left <see cref="CarInfoPacket"/> does not equal the right
        /// <see cref="CarInfoPacket"/>.
        /// </summary>
        /// <param name="left">A <see cref="CarInfoPacket"/> to be compared to right</param>
        /// <param name="right">A <see cref="CarInfoPacket"/> to be compared to left</param>
        /// <returns>true or false</returns>
        public static bool operator !=(Handshaker left, Handshaker right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Identifier ^ this.Version ^ this.OperationId;
        }

        /// <inheritdoc/>
        public bool Equals(Handshaker other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }
    }

    /// <summary>
    /// Structure for the response recieved from the AC Server during handshake operations.
    /// </summary>
    public struct HandshakerResponse : IEquatable<HandshakerResponse>
    {
        /// <summary>
        /// Name of the car bieng driven.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 50)]
        public byte[] CarName;

        /// <summary>
        /// Name of the driver.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 50)]
        public byte[] DriverName;

        /// <summary>
        /// Not Implemented: Always '4242'.
        /// </summary>
        public int Identifier;

        /// <summary>
        /// The version of the AC Client.
        /// </summary>
        public int Version;

        /// <summary>
        /// Name of the track.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 50)]
        public byte[] TrackName;

        /// <summary>
        /// Configuration of the track.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 50)]
        public byte[] TrackConfig;

        /// <summary>
        /// Returns true if the left <see cref="CarInfoPacket"/> does equal the right
        /// <see cref="CarInfoPacket"/>.
        /// </summary>
        /// <param name="left">A <see cref="CarInfoPacket"/> to be compared to right</param>
        /// <param name="right">A <see cref="CarInfoPacket"/> to be compared to left</param>
        /// <returns>true or false</returns>
        public static bool operator ==(HandshakerResponse left, HandshakerResponse right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Returns true if the left <see cref="CarInfoPacket"/> does not equal the right
        /// <see cref="CarInfoPacket"/>.
        /// </summary>
        /// <param name="left">A <see cref="CarInfoPacket"/> to be compared to right</param>
        /// <param name="right">A <see cref="CarInfoPacket"/> to be compared to left</param>
        /// <returns>true or false</returns>
        public static bool operator !=(HandshakerResponse left, HandshakerResponse right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.DriverName.GetHashCode()
                ^ this.CarName.GetHashCode()
                ^ this.TrackConfig.GetHashCode()
                ^ this.TrackName.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(HandshakerResponse other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }
    }
}
