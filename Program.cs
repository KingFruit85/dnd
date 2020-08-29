using System;
using Character;
using Names;

namespace dnd
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomCharacter newCharacter = new RandomCharacter();
            // newCharacter.SetRandomName();
            // newCharacter.SetRandomRace();
            newCharacter.Randomise();
            Console.WriteLine($"Name:{newCharacter.FirstName} {newCharacter.LastName}. Race:{newCharacter.Race}" );
        }
    }
}
