using System;
using System.Reflection;


[assembly: Obfuscation(Exclude = false, Feature = "namespace ('OQ.MineBot.PluginBase.Classes.Crafting.Exposed'):-rename")]

namespace OQ.MineBot.PluginBase.Classes.Crafting.Exposed
{
    public class IRecipe
    {
        // Item that the recipe ouputs.
        public short output { get; private set; }
        // Items that the recipe requires.
        public short[,] inputs { get; private set; }

        public bool requiresCraftingTable => inputs?.GetLength(0) == 3 && GetMaComponentDistance() == 3;

        private int GetMaComponentDistance() {
            int maxVertical = -1, minVertical = -1, maxHorizontal = -1, minHorizontal = -1;
            for (int i = 0; i < inputs.GetLength(0); i++) {
                for (int j = 0; j < inputs.GetLength(1); j++) {
                    if (inputs[i, j] > 0) {
                        if (maxVertical == -1 || i > maxVertical) maxVertical = i;
                        if (minVertical == -1 || i < minVertical) minVertical = i;
                        if (maxHorizontal == -1 || j > maxHorizontal) maxHorizontal = j;
                        if (minHorizontal == -1 || j < minHorizontal) minHorizontal = j;
                    }
                }
            }

            return 1+Math.Max(maxVertical-minVertical, maxHorizontal-minHorizontal);
        }

        public IRecipe(short output, short[,] inputs) {
            this.output = output;
            this.inputs = inputs;
        }

        public short[,] GetInputs(CraftingSlotType type) {
            if (inputs == null) return null;
            if(requiresCraftingTable && type == CraftingSlotType.Inventory) throw new Exception("Recipe requires crafting table, but inventory is open.");

            if (!requiresCraftingTable && type == CraftingSlotType.Table)
                return new short[3, 3]
                {
                    {0, 0, 0},
                    {inputs[0, 0], inputs[0, 1], 0},
                    {inputs[1, 0], inputs[1, 1], 0},
                };

            // No conversion required.
            return inputs;
        }
    }
}