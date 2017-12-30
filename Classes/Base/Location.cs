using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text;
using OQ.MineBot.PluginBase.Classes;

namespace OQ.MineBot.Protocols.Classes.Base
{
    public class Location : ILocation
    {
        public delegate byte[] ConvertToBytes(long value);
        public static ConvertToBytes GetEndianedBytes { get; set; }

        public int x { get; set; }
        public float y { get; set; }
        public int z { get; set; }
        public static IEqualityComparer<ILocation> Comparer { get; set; } = new LocationComparer();

        public Location(int x, float y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Calculate total difference
        /// between 2 distances.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float Distance(ILocation other) {
            if (other == null) return 0;

            var _x = x - other.x;
            var _y = y - other.y;
            var _z = z - other.z;

            return (float)Math.Abs(Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2) + Math.Pow(_z, 2)));
        }

        /// <summary>
        /// Check if 2 locations have
        /// the same values.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Compare(ILocation other) {
            if (other == null) return false;
            return x == other.x && y == other.y && z == other.z;
        }

        /// <summary>
        /// Convert to byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes() {

            var tempValue = (((long)x & 0x3FFFFFF) << 38) | (((long)y & 0xFFF) << 26) | ((long)z & 0x3FFFFFF);
            return GetEndianedBytes(tempValue);
        }

        /// <summary>
        /// Converts location to poisition.
        /// </summary>
        /// <returns></returns>
        public IPosition ToPosition(double addY = Double.NaN) {
            return new Position(x+0.5, y + (double.IsNaN(addY)?0:addY), z+0.5);
        }

        /// <summary>
        /// Returns a new ilocation with
        /// an offset.
        /// </summary>
        /// <returns></returns>
        public ILocation Offset(int x, float y, int z) {
            return new Location(this.x + x, (int)Math.Ceiling(this.y + y), this.z + z);
        }

        /// <summary>
        /// Returns a new location with
        /// a height offset.
        /// </summary>
        /// <returns></returns>
        public ILocation Offset(float y) {
            return new Location(this.x, (int)Math.Ceiling(this.y + y), this.z);
        }

        /// <summary>
        /// Returns a new location with
        /// a height offset.
        /// </summary>
        /// <returns></returns>
        public ILocation Offset(ILocation l) {
            return new Location(this.x + l.x, (int)Math.Ceiling(this.y + l.y), this.z + l.z);
        }

        public ILocation Multiply(int mult) {
            return new Location(this.x * mult, this.y * mult, this.z * mult);
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
            return x.x == y.x && x.y == y.y && x.z == y.z;
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
            return obj.x*2 + (int)obj.y*9 + obj.z*34;
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return this.x * 2 + (int)this.y * 9 + this.z * 34;
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

            return loc.x == this.x && loc.y == this.y && loc.z == this.z;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() {
            return this.x + "/" + this.y + "/" + this.z;
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
            return x.x == y.x && x.z == y.z && Math.Abs(x.y - y.y) <= 1;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public int GetHashCode(ILocation obj) {
            return obj.x * 2 + (int)obj.y * 9 + obj.z * 34;
        }
    }
}