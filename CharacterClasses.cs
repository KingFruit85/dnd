using System;
using System.Collections.Generic;

namespace Character
{
    public class CharacterClassList
    {
        // private string[] CharacterClasses = {"Bard", "Barbarian", "Cleric", "Fighter", "Monk", "Paladin", "Ranger",
        //                                      "Rogue", "Sorcerer", "Warlock", "Wizard", "Druid"};

        private List<string> CharacterClasses = new List<string>(){"Wizard"};


        public string GetRandomClass()
        {
            int i = new Random().Next(0,CharacterClasses.Count);
            return CharacterClasses[i];
        }

        
    }
}