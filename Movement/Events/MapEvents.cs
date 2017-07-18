using OQ.MineBot.PluginBase.Movement.Geometry;
using OQ.MineBot.PluginBase.Movement.Maps;

namespace OQ.MineBot.PluginBase.Movement.Events
{
    public class MapEvents
    {
        public delegate void GeneralUpdate(IAreaMap map);
        public delegate void SearchUpdate(IAreaMap map, bool found);
        public delegate void CuboidUpdate(IAreaMap map, IAreaCuboid cuboid);
    }
}