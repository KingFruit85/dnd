using System.Linq;
using Character;
using Dice;
using Races;

namespace dnd
{
    class Program
    {
        static void Main(string[] args)
        {

            RandomCharacter newCharacter = new RandomCharacter();
            newCharacter.PrintCharacterInfoToConsole();
        }



    }
}
