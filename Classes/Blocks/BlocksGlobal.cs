namespace OQ.MineBot.PluginBase.Classes.Blocks
{
    public static class BlocksGlobal
    {
        public const int LADDER_ID = 65;
        public const int VINE_ID = 106;
        public const int COBWEB_ID = 30;
        public static int[] DOORS =
        {
            64, 71, 193, 194, 195, 196, 197
        };
        public static int[] GATES =
        {
            107, 183, 184, 185, 186, 187
        };
        public static int[] FENCES =
        {
            85, 107, 113, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193
        };
        public static ushort[] BUILDING_BLOCKS = 
        {4, 1, 3, 2, 5, 17, 24, 35, 45, 87, 98, 121, 125, 159, 155, 162, 172, 174, 179};

        public static IBlockHolder blockHolder { get; set; }
    }
}