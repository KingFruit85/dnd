using System;
using System.Linq;

namespace Dice
{
    class DiceTypes
    {
        public int[][] RollD20(int count = 1)
        {
            // -- Declare the array of two elements
            // -- [0] to be an array of results
            // -- [1] to be the sum of [0]
            int[][] Results = new int[][]
            {
                new int[count],
                new int[1]
            };

            // -- Rolls the requested number of die
            // -- appending each roll to the results array 
            for (int c = 0; c < count; c++)
            {
                var r = new Random();
                int i = r.Next(1,20);
                Results[0][c] = i;
            }
            
            // -- Sums all the values and returns the array
            Results[1][0] = Results[0].Sum();
            return Results;
        }

        public int[][] RollD12(int count = 1)
        {
            // -- Declare the array of two elements
            // -- [0] to be an array of results
            // -- [1] to be the sum of [0]
            int[][] Results = new int[][]
            {
                new int[count],
                new int[1]
            };

            // -- Rolls the requested number of die
            // -- appending each roll to the results array 
            for (int c = 0; c < count; c++)
            {
                var r = new Random();
                int i = r.Next(1,12);
                Results[0][c] = i;
            }
            
            // -- Sums all the values and returns the array
            Results[1][0] = Results[0].Sum();
            return Results;
        }

        public int[][] RollD10(int count = 1)
        {
            // -- Declare the array of two elements
            // -- [0] to be an array of results
            // -- [1] to be the sum of [0]
            int[][] Results = new int[][]
            {
                new int[count],
                new int[1]
            };

            // -- Rolls the requested number of die
            // -- appending each roll to the results array 
            for (int c = 0; c < count; c++)
            {
                var r = new Random();
                int i = r.Next(1,10);
                Results[0][c] = i;
            }
            
            // -- Sums all the values and returns the array
            Results[1][0] = Results[0].Sum();
            return Results;
        }

        public int[][] RollD8(int count = 1)
        {
            // -- Declare the array of two elements
            // -- [0] to be an array of results
            // -- [1] to be the sum of [0]
            int[][] Results = new int[][]
            {
                new int[count],
                new int[1]
            };

            // -- Rolls the requested number of die
            // -- appending each roll to the results array 
            for (int c = 0; c < count; c++)
            {
                var r = new Random();
                int i = r.Next(1,8);
                Results[0][c] = i;
            }
            
            // -- Sums all the values and returns the array
            Results[1][0] = Results[0].Sum();
            return Results;
        }

        public int[][] RollD6(int count = 1)
        {
            // -- Declare the array of two elements
            // -- [0] to be an array of results
            // -- [1] to be the sum of [0]
            int[][] Results = new int[][]
            {
                new int[count],
                new int[1]
            };

            // -- Rolls the requested number of die
            // -- appending each roll to the results array 
            for (int c = 0; c < count; c++)
            {
                var r = new Random();
                int i = r.Next(1,6);
                Results[0][c] = i;
            }
            
            // -- Sums all the values and returns the array
            Results[1][0] = Results[0].Sum();
            return Results;
        }

        public int[][] RollD4(int count = 1)
        {
            // -- Declare the array of two elements
            // -- [0] to be an array of results
            // -- [1] to be the sum of [0]
            int[][] Results = new int[][]
            {
                new int[count],
                new int[1]
            };

            // -- Rolls the requested number of die
            // -- appending each roll to the results array 
            for (int c = 0; c < count; c++)
            {
                var r = new Random();
                int i = r.Next(1,4);
                Results[0][c] = i;
            }
            
            // -- Sums all the values and returns the array
            Results[1][0] = Results[0].Sum();
            return Results;
        }

        public int[] ReturnAbilityScores()
        {
            int[] Results = new int[6];

            for (int i = 0; i < Results.Length; i++)
            {
                // -- gets the 4 die roles
                var Rolls = RollD6(4)[0];

                // -- Sorts the rolls and removes the lowest value
                Array.Sort(Rolls);
                Rolls = Rolls.Skip(1).ToArray();

                // -- Sums the remaining values and adds the result to the results
                Results[i] = Rolls.Sum();
                
            }

            // -- Sorts and returns the results in a decending order
            Array.Sort(Results);
            Array.Reverse(Results);

            return Results;
        }
    }
    
}