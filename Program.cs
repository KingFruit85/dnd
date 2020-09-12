using Character;
using System.Collections.Generic;
using Spells;
using System.Linq;
using System;

namespace dnd
{
    class Program
    {
        static void Main(string[] args)
        {

            RandomCharacter newCharacter = new RandomCharacter();
            newCharacter.Randomise();
            newCharacter.PrintCharacterInfoToConsole();
        }
    }
}
