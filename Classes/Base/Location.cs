using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Protocol;

namespace OQ.MineBot.Protocols.Classes.Base
{
    public class Location : ILocation
    {
        public delegate byte[] ConvertToBytes(long value);
        public static ConvertToBytes GetEndianedBytes { get; set; }

        public int X { get; set; }
        public float Y { get; set; }
        public int Z { get; set; }
        public static IEqualityComparer<ILocation> Comparer { get; set; } = new LocationComparer();

        public Location(int x, float y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public Location(long data)
        {
            if (ProtocolGlobalSettings.PROTOCOL > 477) {
                this.X = (int)(data >> 38);
                this.Y = data & 0xFFF;
                this.Z = (int)((data << 26 >> 38));
            }
            else {
                this.X = (int)(data >> 38);
                this.Y = ((data >> 26) & 0xFFF);
                this.Z = (int)((data << 38 >> 38));
            }
        }

        /// <summary>
        /// Calculate total difference
        /// between 2 distances.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float Distance(ILocation other) {
            if (other == null) return 0;

            var _x = X - other.X;
            var _y = Y - other.Y;
            var _z = Z - other.Z;

            return (float)Math.Abs(Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2) + Math.Pow(_z, 2)));
        }

        public float DistanceHorizontal(ILocation other) {
            if (other == null) return 0;

            var _x = X - other.X;
            var _z = Z - other.Z;

            return (float)Math.Abs(Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_z, 2)));
        }

        /// <summary>
        /// Check if 2 locations have
        /// the same values.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Compare(ILocation other) {
            if (other == null) return false;
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        /// Convert to byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes() {
            var tempValue = ProtocolGlobalSettings.PROTOCOL > 477
                ? ((((long) X & 0x3FFFFFF) << 38) | (((long)Z & 0x3FFFFFF) << 12) | ((long)Y & 0xFFF))
                : ((((long) X & 0x3FFFFFF) << 38) | (((long) Y & 0xFFF) << 26) | ((long) Z & 0x3FFFFFF));
            return GetEndianedBytes(tempValue);
        }

        /// <summary>
        /// Converts location to poisition.
        /// </summary>
        /// <returns></returns>
        public IPosition ToPosition(double addY = Double.NaN) {
            return new Position(X+0.5, Y + (double.IsNaN(addY)?0:addY), Z+0.5);
        }

        /// <summary>
        /// Returns a new ilocation with
        /// an offset.
        /// </summary>
        /// <returns></returns>
        public ILocation Offset(int x, float y, int z) {
            return new Location(this.X + x, (int)Math.Ceiling(this.Y + y), this.Z + z);
        }

        /// <summary>
        /// Returns a new location with
        /// a height offset.
        /// </summary>
        /// <returns></returns>
        public ILocation Offset(float y) {
            return new Location(this.X, (int)Math.Ceiling(this.Y + y), this.Z);
        }

        /// <summary>
        /// Returns a new location with
        /// a height offset.
        /// </summary>
        /// <returns></returns>
        public ILocation Offset(ILocation l) {
            return new Location(this.X + l.X, (int)Math.Ceiling(this.Y + l.Y), this.Z + l.Z);
        }

        public ILocation Multiply(int mult) {
            return new Location(this.X * mult, this.Y * mult, this.Z * mult);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
        public bool Equals(ILocation x, ILocation y)
        {
            return x.X == y.X && x.Y == y.Y && x.Z == y.Z;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public int GetHashCode(ILocation obj)
        {
            return obj.X*2 + (int)obj.Y*9 + obj.Z*34;
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return this.X * 2 + (int)this.Y * 9 + this.Z * 34;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            ILocation loc = obj as ILocation;

            if (loc == null)
                return false;

            return loc.X == this.X && loc.Y == this.Y && loc.Z == this.Z;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() {
            return this.X + "/" + this.Y + "/" + this.Z;
        }

        public static ILocation Parse(string value) {

            var split = value.Split('/');
            if (split.Length != 3) return null;

            return new Location(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }
    }

    public class LocationComparer : IEqualityComparer<ILocation>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
        public bool Equals(ILocation x, ILocation y) {

            if (x == null || y == null) return false;
            return x.X == y.X && x.Z == y.Z && Math.Abs(x.Y - y.Y) <= 1;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public int GetHashCode(ILocation obj) {
            return obj.X * 2 + (int)obj.Y * 9 + obj.Z * 34;
        }
    }
}