// <copyright file="CarInfoPacketEquality.cs" company="Racing Sim Tools">
// Copyright (c) Racing Sim Tools. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace AcUdpNet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Basic equality comparer using only the time of the packet.
    /// Used to detect if game is paused.
    /// </summary>
    public class CarInfoPacketEquality : EqualityComparer<CarInfoPacket>
    {
        /// <inheritdoc/>
        public override bool Equals(CarInfoPacket x, CarInfoPacket y)
        {
            return x.LapTime == y.LapTime;
        }

        /// <inheritdoc/>
        public override int GetHashCode(CarInfoPacket obj)
        {
            return obj.GetHashCode();
        }
    }
}
