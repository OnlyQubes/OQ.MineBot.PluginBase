using System;
using System.Collections;
using System.Collections.Generic;
using OQ.MineBot.PluginBase.Classes.World;
using OQ.MineBot.Protocols.Classes.Base;

namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class IRadius
    {
        public ILocation start;
        public int height, xSize, zSize;

        public IRadius() {
        }

        public bool IsInside(ILocation location) {
            return start.X + xSize >= location.X &&
                   start.X <= location.X &&
                   start.Y + height >= location.Y &&
                   start.Y <= location.Y &&
                   start.Z + zSize >= location.Z &&
                   start.Z <= location.Z;
        }

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
            int xMax = Math.Max(start.X, end.X);
            int xMin = Math.Min(start.X, end.X);
            //Get zWidths.
            int zMax = Math.Max(start.Z, end.Z);
            int zMin = Math.Min(start.Z, end.Z);

            //Update the y/w/l.
            this.xSize = xMax - xMin;
            this.zSize = zMax - zMin;
            //Update the start position.
            this.start = new Location(xMin, this.start.Y, zMin);
        }

        private void Recalculate(ILocation end) {

            //Get total y.
            float yMax = Math.Max(start.Y, end.Y);
            float yMin = Math.Min(start.Y, end.Y);

            //Get xWidths.
            int xMax = Math.Max(start.X, end.X);
            int xMin = Math.Min(start.X, end.X);
            //Get zWidths.
            int zMax = Math.Max(start.Z, end.Z);
            int zMin = Math.Min(start.Z, end.Z);

            //Update the y/w/l.
            this.xSize = xMax - xMin;
            this.zSize = zMax - zMin;
            this.height = (int) (yMax - yMin);
            //Update the start position.
            this.start = new Location(xMin, yMin, zMin);
        }

        public ILocation GetClosestWalkable(IWorld world, ILocation toLocation, bool highestOnly = false) {
            if (start == null) return null;

            ILocation currentClosest = null;
            float distance = 0;
            float tempDistance = 0;
            for (int x = start.X; x <= start.X + xSize; x++)
                for (int z = start.Z; z <= start.Z + zSize; z++) {
                    for (int y = (int) start.Y + height; y >= (int) start.Y; y--) {
                        var temp = new Location(x, y, z);
                        if (((IWorld)world).IsWalkable(temp) &&
                            (currentClosest == null || (distance > (tempDistance = toLocation.Distance(temp)) &&
                                                        (!highestOnly || currentClosest.Y <= temp.Y)))) {
                            currentClosest = temp;
                            distance = tempDistance;
                            break;
                        }
                    }
                }
            return currentClosest;
        }

        public override string ToString() {
            return ("Radius { start: "+start+"\t:: end: "+(start.X + xSize)+"/"+(start.Y+height)+"/"+ (start.Z + zSize) + "}");    
        }
    }
}