using System;
using System.Collections.Generic;

namespace Character
{
    public class CharacterClassList
    {
        // private string[] CharacterClasses = {"Bard", "Barbarian", "Cleric", "Fighter", "Monk", "Paladin", "Ranger",
        //                                      "Rogue", "Sorcerer", "Warlock", "Wizard", "Druid"};

        // DONE List :- Bard | Barbarian | Cleric | Fighter

        // private List<string> CharacterClasses = new List<string>(){"Bard", "Barbarian", "Cleric", "Fighter", "Monk"};
        private List<string> CharacterClasses = new List<string>(){"Paladin"};


        public string GetRandomClass()
        {
            int i = new Random().Next(0,CharacterClasses.Count);
            return CharacterClasses[i];
        }

        
    }
}