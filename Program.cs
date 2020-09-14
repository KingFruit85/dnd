using Character;
using Dice;

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
