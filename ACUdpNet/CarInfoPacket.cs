// <copyright file="CarInfoPacket.cs" company="Racing Sim Tools">
// Copyright (c) Racing Sim Tools. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
#pragma warning disable CA1051
namespace AcUdpNet
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Struct representing the packet with car info from Asetto Corsa
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarInfoPacket : IEquatable<CarInfoPacket>
    {
        /// <summary>
        /// Always seems to be the char `A`.
        /// (Byte: 0).
        /// </summary>
        public byte Identifier;

        /// <summary>
        /// Size of the struct in bytes.
        /// (Byte: 1).
        /// </summary>
        public int StructSize;

        /// <summary>
        /// Vehicle speed in km/h.
        /// (Byte: 5).
        /// </summary>
        public float SpeedKmh;

        /// <summary>
        /// Vehicle speed in miles/h.
        /// (Byte: 9).
        /// </summary>
        public float SpeedMph;

        /// <summary>
        /// Vehicle speed in m/s (meters per second).
        /// (Byte: 13).
        /// </summary>
        public float SpeedMs;

        /// <summary>
        /// A one byte bool indicating if ABS is enabled.
        /// (Byte: 17).
        /// </summary>
        public byte AbsEnabled;

        /// <summary>
        /// A one byte bool indicating if ABS is in action.
        /// (Byte: 18).
        /// </summary>
        public byte AbsInAction;

        /// <summary>
        /// A one byte bool indicating if TC is enabled.
        /// (Byte: 19).
        /// </summary>
        public byte TcEnabled;

        /// <summary>
        /// A one byte bool indicating if TC is in action.
        /// (Byte: 20).
        /// </summary>
        public byte TcInAction;

        /// <summary>
        /// A one byte bool indicating if the car is in the pits.
        /// (Byte: 21).
        /// </summary>
        public byte InPit;

        /// <summary>
        /// A one byte bool indicating if the engine limiter is on.
        /// (Byte: 22).
        /// </summary>
        public byte EngineLimiterOn;

        /// <summary>
        /// Unknown byte.
        /// (Byte: 23).
        /// </summary>
        public byte UnknownByte1;

        /// <summary>
        /// Unknown byte.
        /// (Byte: 24).
        /// </summary>
        public byte UnknownByte2;

        /// <summary>
        /// Accelerative G force in the vertical orientation, relative to the car.
        /// (Byte: 25).
        /// </summary>
        public float AccVerticalG;

        /// <summary>
        /// Accelerative G force in the horizontal orientation, relative to the car.
        /// (Byte: 29).
        /// </summary>
        public float AccHorizontalG;

        /// <summary>
        /// Accelerative G force in the frontal orientation, relative to the car.
        /// (Byte: 33).
        /// </summary>
        public float AccFrontalG;

        /// <summary>
        /// Current Lap Time in miliseconds.
        /// (Byte: 37).
        /// </summary>
        public uint LapTime;

        /// <summary>
        /// Previous Lap Time in miliseconds.
        /// (Byte: 41).
        /// </summary>
        public uint LastLap;

        /// <summary>
        /// Best lap time in miliseconds.
        /// (Byte: 45).
        /// </summary>
        public uint BestLap;

        /// <summary>
        /// The lap number of the current lap - starting at 0.
        /// (Byte: 49).
        /// </summary>
        public uint LapCount;

        /// <summary>
        /// The input of the throttle as a fraction. 0 = none, 1 = max.
        /// (Byte: 53).
        /// </summary>
        public float ThrottleInput;

        /// <summary>
        /// The input of the brake as a fraction. 0 = none, 1 = max.
        /// (Byte: 57).
        /// </summary>
        public float BrakeInput;

        /// <summary>
        /// The input of the clutch as a fraction. 0 = none, 1 = max.
        /// (Byte: 61).
        /// </summary>
        public float ClutchInput;

        /// <summary>
        /// The Revolutions Per Minute of the engine.
        /// (Byte: 65).
        /// </summary>
        public float EngineRPM;

        /// <summary>
        /// Steering input angle in degrees. Negative is left - positive is right.
        /// (Byte: 69).
        /// </summary>
        public float SteeringInput;

        /// <summary>
        /// Selected Gear. Reverse = 0, Neutral = 1, 1st Gear = 2, etc.
        /// (Byte: 73).
        /// </summary>
        public uint SelectedGear;

        /// <summary>
        /// Height from the ground of the centre of gravity in meters.
        /// (Byte: 77).
        /// </summary>
        public float CentreOfGravity;

        /// <summary>
        /// Rotational Speed of the wheels in Revolutions Per Minute.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 81).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelAngularSpeed;

        /// <summary>
        /// Difference between the angle that the tyre is pointed in and the
        /// direction it is rolling.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 97).
        /// </summary>
        public float[] SlipAngle;

        /// <summary>
        /// Unsure: Seems to always output 0.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 113).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SlipAngleContactPatch;

        /// <summary>
        /// Difference between the tyre rotation and the motion of the car.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 129).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SlipRatio;

        /// <summary>
        /// Unsure: Seems to alwyas output 0.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 145).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreSlip;

        /// <summary>
        /// Non-Directional slip: Not documented. (TODO: Document).
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 161).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] NdSlip;

        /// <summary>
        /// Downwards force on each wheel in Newtons (TODO: Confirm unit).
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 177).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Load;

        /// <summary>
        /// Undocumented: suspension? (TODO: Document).
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 193).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Dy;

        /// <summary>
        /// Self-aligning torque in Newton meters. (TODO: Confirm unit).
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 209).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] Mz;

        /// <summary>
        /// Amount of dirt on the tyre - seems to max out at 5.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 225).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreDirtLevel;

        /// <summary>
        /// Camber angle in radians.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 241).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] CamberAngle;

        /// <summary>
        /// Tyre radius in meters.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 257).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreRadius;

        /// <summary>
        /// Loaded tyre radius in meters.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 273).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreLoadedRadius;

        /// <summary>
        /// Suspension height in meters.
        /// [ FL = 0, FR = 1, RL = 2, RR = 3].
        /// (Byte: 289).
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspensionHeight;

        /// <summary>
        /// The position of the car around the circuit. 0 = start, 1 = finish.
        /// </summary>
        public float NormalizedCarPosition;

        /// <summary>
        /// Unsure: Seems to always output 0.
        /// </summary>
        public float CarSlope;

        /// <summary>
        /// The coordinates of the car in the world.
        /// [ x = 0, y = 1, z = 2 ]
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] CarCoordinates;

        /// <summary>
        /// Returns true if the left <see cref="CarInfoPacket"/> does equal the right
        /// <see cref="CarInfoPacket"/>.
        /// </summary>
        /// <param name="left">A <see cref="CarInfoPacket"/> to be compared to right</param>
        /// <param name="right">A <see cref="CarInfoPacket"/> to be compared to left</param>
        /// <returns>true or false</returns>
        public static bool operator ==(CarInfoPacket left, CarInfoPacket right)
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
        public static bool operator !=(CarInfoPacket left, CarInfoPacket right)
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
            return this.LapTime.GetHashCode()
                ^ this.LapCount.GetHashCode()
                ^ this.SuspensionHeight.GetHashCode()
                ^ this.SteeringInput.GetHashCode()
                ^ this.EngineRPM.GetHashCode();
        }

        /// <inheritdoc/>
        public bool Equals(CarInfoPacket other)
        {
            return this.GetHashCode() == other.GetHashCode();
        }
    }
}
