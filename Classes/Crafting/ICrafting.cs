using System;
using System.Runtime.CompilerServices;

namespace OQ.MineBot.PluginBase.Classes.Crafting
{
    public interface ICrafting
    {
        /// <summary>
        /// Attempts to craft the specified crafting task.
        /// Once it's done it will call task.callback with the
        /// parameters (bool sucess, CraftinError error [if !success])
        /// </summary>
        /// <param name="task">Use "CraftingTask.Create" to create a task.</param>
        /// <example>
        /// // Craft pickaxe
        /// player.crafting.Craft(CraftingTask.Create(new IRecipe(-1, new short[3,3] {
        ///     { 264, 264, 264 },
        ///     { 0, 280, 0 },
        ///     { 0, 280, 0},
        /// }), amount , (b, error) => {
        ///     Console.WriteLine("Crafting result: { " + b + (b ? "" : ", " + error) + " }");
        /// }));
        /// </example>
        void Craft(CraftingTask task);

        /// <summary>
        /// Determines how many items it can craft
        /// based on your input grid and the bots inventory.
        /// (Ignores task.amount)
        /// </summary>
        int GetMaxCrafts(CraftingTask task);
    }

    public class CraftingTask
    {
        public IRecipe recipe;

        // Amount to be crafted.
        public int amount;
        // How many items have been already crafted.
        public int craftedAmount;

        // Called once the crafting task is complete or cancelled.
        // * If bool is false then CraftingError is provided.
        public Action<bool, CraftingError> callback;

        public static CraftingTask Create(IRecipe recipe, int amount, Action<bool, CraftingError> callback) {
            return new CraftingTask()
            {
                amount = amount,
                recipe = recipe,
                callback = callback
            };
        }
        // Crafts as many items as it can.
        public static CraftingTask Create(IRecipe recipe, Action<bool, CraftingError> callback) {
            return new CraftingTask()
            {
                amount = -1,
                recipe = recipe,
                callback = callback
            };
        }
    }

    public enum CraftingSlotType
    {
        Inventory,
        Table
    }

    public enum CraftingError
    {
        none = 0,

        unexpected_error = 1,
        crafting_in_progress = 2,
        crafting_table_not_opened = 3,
        not_enough_materials = 4,
        inventory_full = 5 // Can't craft anymore items, too full..
    }
}