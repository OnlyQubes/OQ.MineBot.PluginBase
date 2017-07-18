using System;
using System.Collections;
using System.Text;
using OQ.MineBot.PluginBase.Classes.World;

namespace OQ.MineBot.PluginBase.Utility
{
    public static class ExtensionManager
    {
        public static T[,] ResizeArray<T>(this T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }

        public static int[] Max(this IChunkColumb[,] original)
        {
            //Check if the array is valid.
            if(original.Length == 0) return new int[2];

            int[] curMax = {int.MinValue, int.MinValue};

            for(int x = 0; x < original.GetLength(0); x++)
                for (int z = 0; z < original.GetLength(1); z++)
                {
                    //Check if the input is valid.
                    if (original[x, z] == null) continue;

                    //Check X axis.
                    if (original[x, z].X > curMax[0])
                        curMax[0] = original[x, z].X;

                    //Check Z axis.
                    if (original[x, z].Z > curMax[1])
                        curMax[1] = original[x, z].Z;
                }

            //Repalce the max default values
            //if they are still left, else we
            //could overflow.
            if (curMax[0] == int.MinValue) curMax[0] = 0;
            if (curMax[1] == int.MinValue) curMax[1] = 0;

            return curMax;
        }

        public static int[] Min(this IChunkColumb[,] original)
        {
            //Check if the array is valid.
            if (original.Length == 0) return new int[2];

            int[] curMin = {int.MaxValue, int.MaxValue};

            //Start loop at 1's as we already
            //taken the 0's value.
            for (int x = 0; x < original.GetLength(0); x++)
                for (int z = 0; z < original.GetLength(1); z++)
                {
                    //Check if the input is valid.
                    if (original[x, z] == null) continue;

                    //Check X axis.
                    if (original[x, z].X < curMin[0])
                        curMin[0] = original[x, z].X;

                    //Check Z axis.
                    if (original[x, z].Z < curMin[1])
                        curMin[1] = original[x, z].Z;
                }

            //Repalce the min default values
            //if they are still left, else we
            //could overflow.
            if (curMin[0] == int.MaxValue) curMin[0] = 0;
            if (curMin[1] == int.MaxValue) curMin[1] = 0;

            return curMin;
        }

        /// <summary>
        /// Counts how much active bytes there 
        /// are in the byte.
        /// </summary>
        /// <param name="fullByte"></param>
        /// <returns></returns>
        public static BitArray GetActiveBitCount(this ushort fullByte, out byte activeNr)
        {
            //Create the bitarray.
            var bitarray = new BitArray(BitConverter.GetBytes(fullByte));

            //Count how much are actives.
            byte activeCount = 0;
            for (int i = 0; i < bitarray.Length; i++)
                if (bitarray[i])
                    activeCount++;
            //Output the number we got.
            activeNr = activeCount;

            //Return the bitarray.
            return bitarray;
        }
        public static BitArray GetActiveBitCount(this int fullByte, out byte activeNr)
        {
            //Create the bitarray.
            var bitarray = new BitArray(BitConverter.GetBytes(fullByte));

            //Count how much are actives.
            byte activeCount = 0;
            for (int i = 0; i < bitarray.Length; i++)
                if (bitarray[i])
                    activeCount++;
            //Output the number we got.
            activeNr = activeCount;

            //Return the bitarray.
            return bitarray;
        }
    }
}