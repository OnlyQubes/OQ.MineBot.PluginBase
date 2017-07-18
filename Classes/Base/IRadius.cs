using System;
using OQ.MineBot.Protocols.Classes.Base;

namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class IRadius
    {
        public ILocation start;
        public int height, xSize, zSize;

        public IRadius() { }
        public IRadius(ILocation start, ILocation end) {

            //Update values.
            this.start = start;
            //Update h/w/l.
            this.Recalculate(end);
        }

        public void Update(ILocation start, ILocation end) {
            this.start = start;
            this.Recalculate(end);
        }

        public void UpdateHorizontal(ILocation start, ILocation end) {
            
            //Get xWidths.
            int xMax = Math.Max(start.x, end.x);
            int xMin = Math.Min(start.x, end.x);
            //Get zWidths.
            int zMax = Math.Max(start.z, end.z);
            int zMin = Math.Min(start.z, end.z);

            //Update the y/w/l.
            this.xSize = xMax - xMin;
            this.zSize = zMax - zMin;
            //Update the start position.
            this.start = new Location(xMin, this.start.y, zMin);
        }

        private void Recalculate(ILocation end) {

            //Get total y.
            float yMax = Math.Max(start.y, end.y);
            float yMin = Math.Min(start.y, end.y);

            //Get xWidths.
            int xMax = Math.Max(start.x, end.x);
            int xMin = Math.Min(start.x, end.x);
            //Get zWidths.
            int zMax = Math.Max(start.z, end.z);
            int zMin = Math.Min(start.z, end.z);

            //Update the y/w/l.
            this.xSize = xMax - xMin;
            this.zSize = zMax - zMin;
            this.height = (int)(yMax - yMin);
            //Update the start position.
            this.start = new Location(xMin, yMin, zMin);
        }
    }
}