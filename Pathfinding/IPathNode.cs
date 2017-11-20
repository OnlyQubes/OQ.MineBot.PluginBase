using OQ.MineBot.PluginBase.Classes;

namespace OQ.MineBot.PluginBase.Pathfinding
{
    public interface IPathNode : IHeapItem<IPathNode>
    {
        /// <summary>
        /// How much steps are needed
        /// to reach this point.
        /// </summary>
        int steps { get; set; }
        /// <summary>
        /// Distance from the target.
        /// </summary>
        float distance { get; set; }

        /// <summary>
        /// Cost of the node. Calculated
        /// from steps+distance.
        /// </summary>
        float cost { get; }

        /// <summary>
        /// Location of the node.
        /// </summary>
        ILocation location { get; set; }
        /// <summary>
        /// Is jumping required to reach
        /// this path? 
        /// </summary>
        bool jump { get; set; }
        /// <summary>
        /// Is falling required to reach
        /// this path?
        /// </summary>
        bool fall { get; set; }
        /// <summary>
        /// Is this node walkable?
        /// </summary>
        bool walkable { get; set; }
        /// <summary>
        /// Is there a gap to
        /// get to this block.
        /// </summary>
        bool gap { get; set; }
        /// <summary>
        /// Is this a climbing block?
        /// </summary>
        bool climb { get; set; }
        /// <summary>
        /// Is this a liquid block?
        /// </summary>
        bool swim { get; set; }
        /// <summary>
        /// Array of blocks that need to be mined
        /// for this movement to be valid.
        /// NULL - if nothing to mine.
        /// </summary>
        ILocation[] toMine { get; set; }

        /// <summary>
        /// Node that created this one.
        /// </summary>
        IPathNode parentNode { get; set; }
        
        /// <summary>
        /// Converts to a position.
        /// </summary>
        /// <returns></returns>
        IPosition ToPosition();
    }
}