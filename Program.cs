﻿using System;
using Character;

namespace dnd

{
    class Program
    {
        
        static void Main(string[] args)
        {
            RandomCharacter newCharacter = new RandomCharacter();
            Tools.saveCharacterToJSON(newCharacter);
        }

    }
}

