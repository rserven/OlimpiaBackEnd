using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olimpia.Stadium.Api.Model;

namespace Olimpia.Stadium.Api.Util
{
    public class Generic
    {
        private static readonly Random Random = new Random();

        // Create new random number for a chair  
        public static int RandomNumber(Gate.CardinalDirection location)
        {
            int min;
            int max;

            switch (location)
            {
                case Gate.CardinalDirection.North:
                    min = Constants.NorthMin;
                    max = Constants.NorthMax;
                    break;
                case Gate.CardinalDirection.South:
                    min = 20001;
                    max = 40000;
                    break;
                case Gate.CardinalDirection.West:
                    min = 40001;
                    max = 60000;
                    break;
                case Gate.CardinalDirection.East:
                    min = 60001;
                    max = 80018;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(location), location, null);
            }
            return Random.Next(min, max);
        }

        //Return First Letter 
        public static string ReturnFirstLetter(string word)
        {
            string res = word.Substring(0, 1);
            return res;
        }
    }
}
