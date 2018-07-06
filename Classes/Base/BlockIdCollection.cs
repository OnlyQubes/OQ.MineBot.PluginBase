using System.Linq;

namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class BlockIdCollection
    {
        public BlockID[] collection;

        public BlockIdCollection(BlockID[] blocks) {
            this.collection = blocks;
        }
        public BlockIdCollection(string text) {
            this.collection = Parse(text).collection;
        }

        public static BlockIdCollection Parse(string text) {
            if(string.IsNullOrWhiteSpace(text)) return new BlockIdCollection(new BlockID[0]);

            var split = text.Split(' ');
            var blocks = new BlockID[split.Length];
            for (int i = 0; i < split.Length; i++) {
                var seperate = split[i].Split(':');
                blocks[i] = new BlockID(ushort.Parse(seperate[0]), byte.Parse(seperate[1]));
            }
            return new BlockIdCollection(blocks);
        }

        public override string ToString() {
            if (collection == null || collection.Length == 0) return "";
            return string.Join(" ", collection.Select(x => x.id + ":" + x.metadata));
        }
    }
}