using System;
using OQ.MineBot.PluginBase.Classes;

namespace OQ.MineBot.Protocols.Classes.Base
{
    public class Position : IPosition
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Position(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public void Set(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public ILocation ToLocation(float add) {
            return new Location((int)Math.Floor(X), (float)Y + add, (int)Math.Floor(Z));
        }

        /// <summary>
        /// Is the current position
        /// closser.
        /// (not given)
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsCloser(double x, double y, double z, IPosition position) {

            double our = Math.Abs(x - X) + Math.Abs(y - Y) + Math.Abs(z - Z);
            double other = Math.Abs(x - position.X) + Math.Abs(y - position.Y) + Math.Abs(z - position.Z);

            if (our < other)
                return true;
            return false;
        }

        /// <summary>
        /// Distance from our position to target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public double Distance(IPosition target) {

            double x = Math.Max(X, target.X) - Math.Min(X, target.X);
            double z = Math.Max(Z, target.Z) - Math.Min(Z, target.Z);
            
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2));
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() {
            return "Position: " +  X + "/" + Y + "/" + Z;
        }
    }
}