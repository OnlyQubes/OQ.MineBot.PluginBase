using System.Collections.Generic;
using System.Linq;
using OQ.MineBot.PluginBase.Classes.Crafting.Exposed;

namespace OQ.MineBot.PluginBase.Classes.Crafting
{
    public static class RecipeDictionary
    {
        // Some items can have multiple recipes. Furthermore we do not need
        // it to be fast, as lookups on here will be sparse. Therefore we 
        // can just use a simple list here.
        private static readonly List<IRecipe> recipes = new List<IRecipe>();

        public static IRecipe GetRecipe(short output) {
            for (var i = 0; i < recipes.Count; i++)
                if (recipes[i].output == output) return recipes[i];
            return null;
        }
        public static IRecipe[] GetRecipes(short output) {
            var recipeList = new List<IRecipe>();
            for (var i = 0; i < recipes.Count; i++)
                if (recipes[i].output == output) recipeList.Add(recipes[i]);
            return recipeList.ToArray();
        }

        public static void RegisterRecipe(short output, short[,] inputs) {
            recipes.Add(new IRecipe(output, inputs));
        }
    }
}